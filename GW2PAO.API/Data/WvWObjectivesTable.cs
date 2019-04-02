using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GW2PAO.API.Data;
using GW2PAO.API.Data.Entities;
using GW2PAO.API.Data.Enums;

namespace GW2PAO.API.Data
{
    /// <summary>
    /// The WvW Objectives Table containing all information about the various objectives in WvW
    /// </summary>
    public class WvWObjectivesTable
    {
        /// <summary>
        /// File name for the table
        /// </summary>
        public static readonly string FileName = "WvWObjectives.xml";

        /// <summary>
        /// List of dungeons and their details
        /// </summary>
        public List<Objective> Objectives { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WvWObjectivesTable()
        {
            this.Objectives = new List<Objective>();
        }

        /// <summary>
        /// Loads the WvW objectives table file
        /// </summary>
        /// <returns>The loaded event time table data</returns>
        public static WvWObjectivesTable LoadTable()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(WvWObjectivesTable));
            TextReader reader = new StreamReader(FileName);
            object obj = deserializer.Deserialize(reader);
            WvWObjectivesTable loadedData = (WvWObjectivesTable)obj;
            reader.Close();

            return loadedData;
        }

        /// <summary>
        /// Loads the WvW objectives table file
        /// </summary>
        /// <returns>The loaded event time table data</returns>
        public static void CreateTable()
        {
            WvWObjectivesTable table = new WvWObjectivesTable();
            // Change coordinate / add api obj number
            // Eternal Battleground
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Keep_Overlook, ChatCode = @"[&DAEAAAAmAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(6470.4, 16276.8) }); // 38-1
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Keep_Valley, ChatCode = @"[&DAIAAAAmAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(23896.8, -18902.4) }); // 38-2
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Keep_Lowlands, ChatCode = @"[&DAMAAAAmAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-21348.7, -19101.6) }); // 38-3
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Camp_Golanta, ChatCode = @"[&DAQAAAAmAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-6993.6, -26474.4) }); // 38-4
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Camp_Pangloss, ChatCode = @"[&DAUAAAAmAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(18859.2, 14332.8) }); // 38-5
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Camp_Speldan, ChatCode = @"[&DAYAAAAmAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-15670.8, 18916.8) }); // 38-6
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Camp_Danelon, ChatCode = @"[&DAcAAAAmAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(13053.6, -29332.8) }); // 38-7
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Camp_Umberglade, ChatCode = @"[&DAgAAAAmAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(25639.2, -3271.2) }); // 38-8
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Castle_Stonemist, ChatCode = @"[&DAkAAAAmAAAA]", Type = ObjectiveType.Castle, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(2683.2, -5812.8) }); // 38-9
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Camp_Rogues, ChatCode = @"[&DAoAAAAmAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-22152.7, -2140.8) }); // 38-10
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Aldons, ChatCode = @"[&DAsAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-25923.8, -11011.2) }); // 38-11
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Wildcreek, ChatCode = @"[&DAwAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-14107, -6974.4) }); // 38-12
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Jerrifers, ChatCode = @"[&DA0AAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-16513, -25737) }); // 38-13
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Klovan, ChatCode = @"[&DA4AAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-7732.8, -17947.2) }); // 38-14
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Langor, ChatCode = @"[&DA8AAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(23008.8, -27760.8) }); // 38-15
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Quentin, ChatCode = @"[&DBAAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(8546.4, -21369.6) }); // 38-16
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Mendons, ChatCode = @"[&DBEAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-5697.6, 19670.4) }); // 38-17
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Anzalias, ChatCode = @"[&DBIAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-7324.8, 6040.8) }); // 38-18
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Ogrewatch, ChatCode = @"[&DBMAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(11308.8, 6705.6) }); // 38-19
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Veloka, ChatCode = @"[&DBQAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(14313.6, 20299.2) }); // 38-20
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Durios, ChatCode = @"[&DBUAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(15897.6, -4651.2) }); // 38-21
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Tower_Bravost, ChatCode = @"[&DBYAAAAmAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(30535.2, -11028) }); // 38-22
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Mercenary_Molevekian, ChatCode = @"[&DHsAAAAmAAAA]", Type = ObjectiveType.Mercenary, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-15851.8, 2121.6) }); // 38-123
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Mercenary_Orgath, ChatCode = @"[&DH0AAAAmAAAA]", Type = ObjectiveType.Mercenary, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(18868.8, 4161.6) }); // 38-125
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Mercenary_Darkrait, ChatCode = @"[&DH4AAAAmAAAA]", Type = ObjectiveType.Mercenary, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(3028.8, -27398.4) }); // 38-126
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Spawn_Hill_Red, ChatCode = @"[&DHwAAAAmAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(861.6, 26541.6) }); // 38-124
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Spawn_Hill_Blue, ChatCode = @"[&DIIAAAAmAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(30340.8, -28452) }); // 38-130
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.EB_Spawn_Hill_Green, ChatCode = @"[&DIMAAAAmAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.EternalBattlegrounds, MapLocation = new Point(-29640.5, -27928.8) }); // 38-131

            // Red Desert Borderlands
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_HammsLab, ChatCode = @"[&DGMAAABLBAAA]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-148.8, 24035.76) }); // 1099-99
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_BauerFarmstead, ChatCode = @"[&DGQAAABLBAAA]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(27326.4, -19123.2) }); // 1099-100
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_McLains, ChatCode = @"[&DGUAAABLBAAA]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-27981.12, -19224) }); // 1099-101
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_OdelAcademy, ChatCode = @"[&DGYAAABLBAAA]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-22036.32, 23671.92) }); // 1099-102
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_EternalNecro, ChatCode = @"[&DGgAAABLBAAA]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(23740.8, 20152.08) }); // 1099-104
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_Crankshaft, ChatCode = @"[&DGkAAABLBAAA]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(12165.6, -25370.4) }); // 1099-105
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Keep_Blistering, ChatCode = @"[&DGoAAABLBAAA]", Type = ObjectiveType.Keep, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-34134.72, -3362.4) }); // 1099-106
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_RoysRefuge, ChatCode = @"[&DG0AAABLBAAA]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(32404.8, 11390.4) }); // 1099-109
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_Parched, ChatCode = @"[&DG4AAABLBAAA]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-12146.4, -20095.2) }); // 1099-110
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Keep_Stoic, ChatCode = @"[&DHEAAABLBAAA]", Type = ObjectiveType.Keep, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(638.4, 8966.4) }); // 1099-113
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Keep_Ospreys, ChatCode = @"[&DHIAAABLBAAA]", Type = ObjectiveType.Keep, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(34872, -5092.8) }); // 1099-114
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_Boettigers, ChatCode = @"[&DHMAAABLBAAA]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-34496.4, 11993.76) }); // 1099-115
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_Dustwhisper, ChatCode = @"[&DHQAAABLBAAA]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-64.8, -32637.6) }); // 1099-116
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Spawn_Border_Red, ChatCode = @"[&DG0AAABLBAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(32404.8, 11390.4) }); // 1099-117
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Spawn_Border_Green, ChatCode = @"[&DGwAAABLBAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-26629.7, -30504) }); // 1099-108
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Spawn_Border_Blue, ChatCode = @"[&DGsAAABLBAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(30206.4, -30648) }); // 1099-107
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Ruin_Higgins, ChatCode = @"[&DHYAAABLBAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(3919.2, -16900.8) }); // 1099-118
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Ruin_Bearce, ChatCode = @"[&DHcAAABLBAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-7279.2, -6422.4) }); // 1099-119
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Ruin_Zak, ChatCode = @"[&DHgAAABLBAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(5748, -6823.2) }); // 1099-120
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Ruin_Darra, ChatCode = @"[&DHkAAABLBAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-8414.4, -13572) }); // 1099-121
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Ruin_Tilly, ChatCode = @"[&DHoAAABLBAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-592.8, 972) }); // 1099-122

            // Green Alpine Borderlands
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Keep_Hills, ChatCode = @"[&DCAAAABfAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(28239.6, -5059.2) }); // 95-32
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Keep_Bay, ChatCode = @"[&DCEAAABfAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-25030.6, -6878.4) }); // 95-33
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Keep_Garrison, ChatCode = @"[&DCUAAABfAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-569.76, 5625.6) }); // 95-37
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Redlake, ChatCode = @"[&DCQAAABfAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(12073.2, -17757.6) }); // 95-36
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Bluebriar, ChatCode = @"[&DCMAAABfAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-9338.64, -16056) }); // 95-35
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Sunnyhill, ChatCode = @"[&DCYAAABfAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-15197.5, 14203.2) }); // 95-38
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Cragtop, ChatCode = @"[&DCgAAABfAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(14530.08, 15352.8) }); // 95-40
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Lodge, ChatCode = @"[&DCIAAABfAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(72, -32400) }); // 95-34
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Faithleap, ChatCode = @"[&DDQAAABfAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-20578.1, 11299.2) }); // 95-52
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Bluevale, ChatCode = @"[&DDUAAABfAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-19669.9, -18813.6) }); // 95-53
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Foghaven, ChatCode = @"[&DDMAAABfAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(22892.4, 12828) }); // 95-51
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Redwater, ChatCode = @"[&DDIAAABfAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(22629.6, -19941.6) }); // 95-50
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Titanpaw, ChatCode = @"[&DCcAAABfAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(110.64, 34600.8) }); // 95-39
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Ruin_Patrick, ChatCode = @"[&DEIAAABfAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(6822.48, -10610.4) }); // 95-66
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Ruin_Cohen, ChatCode = @"[&DEEAAABfAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(5978.16, -2088) }); // 95-65
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Ruin_Estate, ChatCode = @"[&DEAAAABfAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-5250.96, -794.4) }); // 95-64
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Ruin_Hollow, ChatCode = @"[&DD8AAABfAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-7608, -9712.8) }); // 95-63
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Ruin_Temple, ChatCode = @"[&DD4AAABfAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-308.88, -16068) }); // 95-62
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Spawn_Citadel_Green, ChatCode = @"[&DG8AAABfAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(564.48 , 23844) }); // 95-111
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Spawn_Border_Red, ChatCode = @"[&DGcAAABfAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(18053.04, -32923.2) }); // 95-103
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Spawn_Border_Blue, ChatCode = @"[&DHAAAABfAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-16679.3, -32548.8) }); // 95-112


            // Blue Alpine Borderlands
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Keep_Garrison, ChatCode = @"[&DCUAAABgAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-568.8, 5625.6) }); // 96-37
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Keep_Bay, ChatCode = @"[&DCEAAABgAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-25029.6, -6878.4) }); // 96-33
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Keep_Hills, ChatCode = @"[&DCAAAABgAAAA]", Type = ObjectiveType.Keep, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(28238.4, -5059.2) }); // 96-32
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Dawns, ChatCode = @"[&DCgAAABgAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(14529.6, 15352.8) }); // 96-40
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Redbriar, ChatCode = @"[&DCMAAABgAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-9338.4, -16056) }); // 96-35
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Greenlake, ChatCode = @"[&DCQAAABgAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(12072, -17757.6) }); // 96-36
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Woodhaven, ChatCode = @"[&DCYAAABgAAAA]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-15196.8, 14203.2) }); // 96-38
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Godslore, ChatCode = @"[&DDQAAABgAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-20577.6, 11299.2) }); // 96-52
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Redvale, ChatCode = @"[&DDUAAABgAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-19670.4, -18813.6) }); // 96-53
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Stargrove, ChatCode = @"[&DDMAAABgAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(22893.6, 12828) }); // 96-51
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Greenwater, ChatCode = @"[&DDIAAABgAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(22629.6, -19941.6) }); // 96-50
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Spiritholme, ChatCode = @"[&DCcAAABgAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(110.4, 34600.8) }); // 96-39
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Demense, ChatCode = @"[&DCIAAABgAAAA]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(72, -32400) }); // 96-34
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Ruin_Carvers, ChatCode = @"[&DEIAAABgAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(6823.2, -10610.4) }); // 96-66
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Ruin_Orchard, ChatCode = @"[&DEEAAABgAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(5978.4, -2088) }); // 96-65
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Ruin_Estate, ChatCode = @"[&DEAAAABgAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-5251.2, -794.4) }); // 96-64
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Ruin_Hollow, ChatCode = @"[&DD8AAABgAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-7608, -9712.8) }); // 96-63
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Ruin_Temple, ChatCode = @"[&DD4AAABgAAAA]", Type = ObjectiveType.Ruin, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-309.6, -16068) }); // 96-62
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Spawn_Citadel_Blue, ChatCode = @"[&DG8AAABgAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(564, 23844) }); // 96-111
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Spawn_Border_Green, ChatCode = @"[&DGcAAABgAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(18052.8, -32923.2) }); // 96-103
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Spawn_Border_Red, ChatCode = @"[&DHAAAABgAAAA]", Type = ObjectiveType.Spawn, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-16680, -32548.8) }); // 96-112

            XmlSerializer serializer = new XmlSerializer(typeof(WvWObjectivesTable));
            TextWriter textWriter = new StreamWriter(FileName);
            serializer.Serialize(textWriter, table);
            textWriter.Close();
        }

        public class Objective
        {
            public WvWObjectiveId ID { get; set; }
            public string ChatCode { get; set; }
            public Point MapLocation { get; set; }
            public ObjectiveType Type { get; set; }
            public WvWMap Map { get; set; }
        }
    }
}
