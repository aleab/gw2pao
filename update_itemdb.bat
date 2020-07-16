@ECHO off
powershell -ExecutionPolicy Unrestricted -NoProfile -Command "& {Get-Content \"%~0\" | Select-Object -skip 4}" >"_update_itemdb.ps1"
powershell -ExecutionPolicy Unrestricted -NoProfile -File ".\_update_itemdb.ps1"
EXIT /B 0

Remove-Item -LiteralPath $MyInvocation.MyCommand.Path -Force

# Constants
$pageSize = 200
$numberOfJobs = 6

$ProgressPreference = 'SilentlyContinue'
$itemsRes = Invoke-WebRequest -Uri "https://api.guildwars2.com/v2/items" -Method Get
$ProgressPreference = 'Continue'

$count = $itemsRes.Headers['X-Result-Total']
$pages = [System.Math]::Ceiling($count / $pageSize)
$page = 0

$Rarity = @{
    Unknown = 0;
    Junk = 1;
    Basic = 2;
    Fine = 4;
    Masterwork = 8;
    Rare = 16;
    Exotic = 32;
    Ascended = 64;
    Legendary = 128;
}

function WriteJobProgress {
    param($Job)

    #Make sure the first child job exists
    if($Job.ChildJobs[0].Progress -ne $null)
    {
        #Extracts the latest progress of the job and writes the progress
        $jobProgressHistory = $Job.ChildJobs[0].Progress;
        $latestProgress = $jobProgressHistory[$jobProgressHistory.Count - 1];
        $latestPercentComplete = $latestProgress | Select -expand PercentComplete;
        $latestActivity = $latestProgress | Select -expand Activity;
        $latestStatus = $latestProgress | Select -expand StatusDescription;
    
        #When adding multiple progress bars, a unique ID must be provided. Here I am providing the JobID as this
        Write-Progress -Id $Job.Id -Activity $latestActivity -Status $latestStatus -PercentComplete $latestPercentComplete;
    }
}

foreach ($lang in 'de','en','es','fr','zh') {
    $jobs = New-Object Collections.Generic.List[System.Management.Automation.Job]

    $dp = [System.Math]::Floor($pages / $numberOfJobs)
    for ($j = 0; $j -lt $numberOfJobs; $j++) {
        $p0 = $dp * $j
        if ($j -eq $numberOfJobs - 1) {
            $p1 = $pages
        } else {
            $p1 = $dp * ($j + 1)
        }

        
        $job = Start-Job -ArgumentList $($PWD.Path, $Rarity, $pageSize, $lang, $p0, $p1, $j) -ScriptBlock {
            param($wd, $Rarity, $pageSize, $lang, $p0, $p1, $j)

            $h = @{}
            $numberOfPages = $p1 - $p0

            for ($p = 0; $p -lt $numberOfPages; $p++) {
                Write-Progress -Activity "#$j | Fetching items [$lang]" -Status "$($p+1) / $numberOfPages" -PercentComplete $((($p+1) / $numberOfPages) * 100)

                $ProgressPreference = 'SilentlyContinue'
                $res = Invoke-WebRequest -Uri "https://api.guildwars2.com/v2/items?lang=${lang}&page_size=${pageSize}&page=$($p0 + $p)" -Method Get
                $ProgressPreference = 'Continue'

                if ($res.StatusCode -eq 200) {
                    $array = $res.Content | ConvertFrom-Json
                    for ($i = 0; $i -lt $array.Length; $i++) {
                        $o = $array[$i] | Select @{n="ID";e={$_.id.ToString()}}, @{n="Name";e={$_.name}}, @{n="Rarity";e={$Rarity[$_.rarity]}}, @{n="Level";e={$_.level}}
                        $h.Add($o.ID, $o)
                    }
                }
            }

            $h | ConvertTo-Json -Compress | Out-File -FilePath "${wd}\tmp.ItemDatabase.${lang}.${j}.json"
        }
        $jobs.Add($job)
    }
    
    $jobs = $jobs.ToArray()
    $result = Wait-Job -Timeout 1 -Job $jobs
    while (!$result -or $result.Length -lt $jobs.Length) {
        $jobs | ForEach { WriteJobProgress($_) }
        $result = Wait-Job -Timeout 1 -Job $jobs
    }

    $h = @{}
    for ($j = 0; $j -lt $numberOfJobs; $j++) {
        Get-Content ".\tmp.ItemDatabase.${lang}.${j}.json" | ConvertFrom-Json | ForEach-Object { $_.PSObject.Properties } | ForEach { $h[$_.Name] = $_.Value }
        Remove-Item ".\tmp.ItemDatabase.${lang}.${j}.json"
    }
    $h | ConvertTo-Json -Compress | New-Item -Force -Path ".\GW2PAO.API\Locale\${lang}\ItemDatabase.json" | Out-Null
}
