using Chapter04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chapter04
{
    [TestClass]
    public class Mp3Tests
    {
        // tip: replace with a valid music folder on your machine
        const string MusicFolder = @"C:\Users\adamo\OneDrive\Music";

        [TestMethod]
        public void FindMp3Files()
        {        
            var files = Mp3Linq.GetMp3InfoLimited(MusicFolder, 100);
            Assert.IsTrue(files.Any());
        }

        [TestMethod]
        public void Find80sMusic()
        {
            var files = Mp3Linq.GetMp3InfoLimitedWhere(MusicFolder, mp3 =>
            {
                try
                {
                    return mp3.Tag.Year >= 1980 && mp3.Tag.Year < 1990;
                }
                catch 
                {
                    // ignore file -- it's probably missing a Tag for some reason
                    return false;
                }                
            }, 200).ToList();

            Assert.IsTrue(files.Any());
        }
    }
}
