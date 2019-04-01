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

            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Keep_Garrison, ChatCode = @"[&BCQFAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-441.6, 9160.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Orchard, ChatCode = @"[&BCUFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-648, -32762.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Redbriar, ChatCode = @"[&BCoFAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-7545.6, -17548.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Greenlake, ChatCode = @"[&BCYFAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(11155.2, -16648.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Keep_Bay, ChatCode = @"[&BCgFAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-22857.6, -6789.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Dawns, ChatCode = @"[&BC0FAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(12969.6, 12840) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Spiritholme, ChatCode = @"[&BB8FAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(232.8, 34180.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Tower_Woodhaven, ChatCode = @"[&BCwFAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-14152.8, 14712) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Keep_Hills, ChatCode = @"[&BCAFAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(22420.8, -5016) });

            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Keep_Hills, ChatCode = @"[&BDAFAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(22421.04, -5016) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Redlake, ChatCode = @"[&BD4FAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(11154.72, -16648.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Orchard, ChatCode = @"[&BDkFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-648, -32762.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Keep_Bay, ChatCode = @"[&BC8FAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-25030.6, -6878.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Bluebriar, ChatCode = @"[&BD0FAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-7544.64, -17548.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Keep_Garrison, ChatCode = @"[&BDIFAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-441.6, 9160.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Sunnyhill, ChatCode = @"[&BDYFAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-14153.52, 14712) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Faithleap, ChatCode = @"[&BDwFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-21083.28, 11462.4) });

            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Bluevale, ChatCode = @"[&BDgFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-19053.12, -18657.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Foghaven, ChatCode = @"[&BDMFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(23253.36, 12273.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Redwater, ChatCode = @"[&BDoFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(22442.16, -19444.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Camp_Titanpaw, ChatCode = @"[&BDEFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(232.8, 34180.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Tower_Cragtop, ChatCode = @"[&BDcFAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(12969.6, 12840) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Godslore, ChatCode = @"[&BCkFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-21084, 11462.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Redvale, ChatCode = @"[&BC4FAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-19053.6, -18657.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Stargrove, ChatCode = @"[&BCEFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(23253.6, 12273.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Camp_Greenwater, ChatCode = @"[&BCYFAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(22442.4, -19444.8) });

        
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Carvers, ChatCode = @"", Type = ObjectiveType.CarversAscent, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(6802.815, -10643.904) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Orchard, ChatCode = @"", Type = ObjectiveType.OrchardOverlook, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(5983.413, -2110.027) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Estate, ChatCode = @"", Type = ObjectiveType.BauersEstate, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-5251.525, -783.006) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Hollow, ChatCode = @"", Type = ObjectiveType.BattlesHollow, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-7939.68, -9885.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.BB_Temple, ChatCode = @"", Type = ObjectiveType.TempleofLostPrayers, Map = WvWMap.BlueAlpineBorderlands, MapLocation = new Point(-279.59, -16015.255) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Carvers, ChatCode = @"", Type = ObjectiveType.CarversAscent, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(6802.815, -10643.904) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Orchard, ChatCode = @"", Type = ObjectiveType.OrchardOverlook, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(5983.413, -2110.027) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Estate, ChatCode = @"", Type = ObjectiveType.BauersEstate, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-5251.525, -783.006) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Hollow, ChatCode = @"", Type = ObjectiveType.BattlesHollow, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-7939.68, -9885.6) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.GB_Temple, ChatCode = @"", Type = ObjectiveType.TempleofLostPrayers, Map = WvWMap.GreenAlpineBorderlands, MapLocation = new Point(-279.59, -16015.255) });

            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_HammsLab,       ChatCode = @"[&BLEIAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-148.8, 24035.76) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_BauerFarmstead, ChatCode = @"[&BPMIAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(27326.4, -19123.2) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_McLains,        ChatCode = @"[&BI4IAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-27981.12, -19224) });      
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_OdelAcademy,   ChatCode = @"[&BN8IAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-22036.32, 23671.92) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_EternalNecro,  ChatCode = @"[&BJUIAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(23740.8, 20152.08) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_Crankshaft,    ChatCode = @"[&BI8IAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(12165.6, -25370.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Keep_Blistering,     ChatCode = @"[&BIYIAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-34134.72, -3362.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_RoysRefuge,     ChatCode = @"[&BPYIAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(32404.8, 11390.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Tower_Parched,       ChatCode = @"[&BEUIAAA=]", Type = ObjectiveType.Tower, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-12146.4, -20095.2) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Keep_Stoic,          ChatCode = @"[&BK8IAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(638.4, 8966.4) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Keep_Ospreys,        ChatCode = @"[&BEMIAAA=]", Type = ObjectiveType.Keep, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(34872, -5092.8) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_Boettigers,     ChatCode = @"[&BCkIAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-34496.4, 11993.76) });
            table.Objectives.Add(new Objective() { ID = WvWObjectiveIds.RB_Camp_Dustwhisper,    ChatCode = @"[&BNMIAAA=]", Type = ObjectiveType.Camp, Map = WvWMap.RedDesertBorderlands, MapLocation = new Point(-64.8, -32637.6) });


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
