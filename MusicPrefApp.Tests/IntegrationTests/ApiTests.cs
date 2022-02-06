using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPrefApp.Services.SpotifyApi.Extensions;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Tests.IntegrationTests
{
    [TestClass]
    public class ApiTests : BaseTest
    {
       [TestMethod]
        public async Task TestSpotifyAuthApiTokenIsRetrieviedCorrectly()
        {
            var authApi = ISpotifyAuthApiExtensions.GetSpotifyAuthApi(_configuration);
            var token = await authApi.GetSpotifyToken(_configuration);
            Assert.IsTrue(!string.IsNullOrEmpty(token.access_token));
        }

        [TestMethod]
        public async Task TestGettingTokenFromCaching()
        {
            await _spotifyApi.GetGenreSeeds();

            Assert.IsTrue(_cache.TryGetValue("Token", out TokenModel model));

            await _spotifyApi.GetGenreSeeds();

            Assert.IsTrue(_cache.TryGetValue("Token", out TokenModel model2));

            Assert.AreEqual(model.access_token, model2.access_token);
        }

        [TestMethod]
        public async Task TestGettingArtistsByGenre()
        {
            var artists = await _spotifyApi.GetArtistsBasedOnGenre("rock");
            Assert.IsNotNull(artists);
            var artistsList = artists.artists.items.OrderByDescending(x => x.popularity).ToList();
            Assert.IsTrue(artistsList.Count != 0);
    
            foreach (var artist in artistsList)
            {
                Debug.WriteLine($"Artist name: {artist.name}, Id: {artist.id}, Popularity: {artist.popularity}");
            }
        }

        [TestMethod]
        public async Task TestGettingTracksByArtists()
        {
            var tracks = await _spotifyApi.GetTracksBasedOnArtist("AC/DC");
            Assert.IsNotNull(tracks);
            var tracksList = tracks.tracks.items.OrderByDescending(x => x.popularity).ToList();
            Assert.IsTrue(tracksList.Count != 0);

            foreach (var track in tracksList)
            {
                Debug.WriteLine($"Track name: {track.name}, Id: {track.id}, Album: {track.album.name}, Popularity: {track.popularity}");
            }
        }

        [TestMethod]
        public async Task TestGettingRecommendations()
        {
            var recs = await _spotifyApi.GetRecommendations("711MCceyCBcFnzjGY4Q7Un", "rock", "08mG3Y1vljYA6bvDt4Wqkj");
            Assert.IsNotNull(recs);
            var recsList = recs.tracks.OrderByDescending(x => x.popularity).ToList();
 
            Assert.IsTrue(recsList.Count != 0);

            foreach (var rec in recsList)
            {
                var artistsString = rec.artists.Aggregate(string.Empty, (current, recArtist) => current + recArtist.name);

                Debug.WriteLine($"Artists: {artistsString}, Track name: {rec.name}, Id: {rec.id}, Album: {rec.album.name}, Popularity: {rec.popularity}");
            }
        }
    }
}
