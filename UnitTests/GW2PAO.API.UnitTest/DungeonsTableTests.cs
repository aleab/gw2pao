using System;
using System.IO;
using GW2PAO.API.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GW2PAO.API.UnitTest
{
    [TestClass]
    public class DungeonsTableTests
    {
        private static readonly string renamedFilename = "renamedFile.xml";

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            if (File.Exists(DungeonsTable.FileName))
                File.Delete(DungeonsTable.FileName);
            if (File.Exists(renamedFilename))
                File.Delete(renamedFilename);

            File.Copy(Path.Combine("TestResources", DungeonsTable.FileName), DungeonsTable.FileName);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.Delete(DungeonsTable.FileName);
            File.Delete(renamedFilename);
        }

        [TestMethod]
        public void DungeonsTable_Constructor()
        {
            DungeonsTable dt = new DungeonsTable();
            Assert.IsNotNull(dt);
            Assert.IsNotNull(dt.Dungeons);
        }

        [TestMethod]
        public void DungeonsTable_LoadTable_Success()
        {
            DungeonsTable dt = DungeonsTable.LoadTable();
            Assert.IsNotNull(dt);
            Assert.IsNotNull(dt.Dungeons);
            Assert.IsTrue(dt.Dungeons.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void DungeonsTable_LoadTable_MissingFile()
        {
            File.Move(DungeonsTable.FileName, renamedFilename);
            try
            {
                DungeonsTable.LoadTable();
            }
            finally
            {
                File.Move(renamedFilename, DungeonsTable.FileName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DungeonsTable_LoadTable_InvalidFile()
        {
            File.Move(DungeonsTable.FileName, renamedFilename);
            File.WriteAllText(DungeonsTable.FileName, "invalid data");

            try
            {
                DungeonsTable.LoadTable();
            }
            finally
            {
                File.Delete(DungeonsTable.FileName);
                File.Move(renamedFilename, DungeonsTable.FileName);
            }
        }

        [TestMethod]
        public void DungeonsTable_CreateTable_Success()
        {
            File.Move(DungeonsTable.FileName, renamedFilename);
            try
            {
                DungeonsTable.CreateTable();
                Assert.IsTrue(File.Exists(DungeonsTable.FileName));
            }
            finally
            {
                if (File.Exists(DungeonsTable.FileName))
                    File.Delete(DungeonsTable.FileName);
                File.Move(renamedFilename, DungeonsTable.FileName);
            }
        }
    }
}
