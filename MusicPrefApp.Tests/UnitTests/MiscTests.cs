using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Tests.UnitTests
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void TestAggregateArtistListReturningProperString()
        {
            var artistList = new List<Artist>
            {
                new() {name = "test", id = "123456789"},
                new() {name = "test2222", id = "101112131415"}
            };
            
              var artistsIds = artistList.Select(x => x.id).Aggregate((s1, s2) => s1 + "," + s2);
            //var artistsIds = artistList.Aggregate(string.Empty, (current, artist) => current + "," + artist.id);

            Assert.AreEqual("123456789,101112131415", artistsIds);
        }
    }
}
