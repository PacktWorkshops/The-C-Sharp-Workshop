using Chapter04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04
{
    [TestClass]
    public class FileLinqTests
    {
        [TestMethod]
        public void GetFileInfosAny()
        {            
            var files = FileLinq.GetFileInfosLimited(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Assert.IsTrue(files.Any());
        }

        [TestMethod]
        public void GetFileInfosAll()
        {
            var files = FileLinq.GetFileInfosAll(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Assert.IsTrue(files.Any());
        }

        [TestMethod]
        public void GetFileInfosLimitCount()
        {
            var files = FileLinq.GetFileInfosLimited(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 10);
            Assert.IsTrue(files.Count() == 10);
        }

        [TestMethod]
        public void GetLargest()
        {
            var largest = FileLinq.GetLargest(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 5);
            Assert.IsTrue(largest.Count() == 5);
        }

        [TestMethod]
        public void GetRecentByExtension()
        {
            var recentByExt = FileLinq.GetRecentByExtension(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 5);
            Assert.IsTrue(recentByExt.All(ext => ext.Count() <= 5));
        }        

        [TestMethod]
        public void PartitionByDate()
        {
            var ages = new Dictionary<int, string>()
            {
                [0] = "Recent",
                [1] = "A Bit Ago",
                [2] = "A While Ago"
            };

            var partitions = FileLinq.PartitionBy(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 3, 
                fi => fi.LastWriteTime).Select(grp => new
                {
                    Text = $"{ages[grp.Key]}, from {grp.Min(fi => fi.LastWriteTime):M/d/yy} to {grp.Max(fi => fi.LastWriteTime):M/d/yy}",
                    Files = grp
                });
        }
    }
}
