using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPrefApp.Application.Interfaces;
using MusicPrefApp.Services.SpotifyApi;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Application
{
    public class SpotifyRecommendationEngine : IRecommendationEngine
    {
        private readonly ISpotifyApi _spotifyApi;

        public SpotifyRecommendationEngine(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
        }

        public async Task<List<Track>> GetRecommendations(List<string> likedGenres, List<Artist> likedArtists, List<Track> likedTracks)
        {

            // TODO: Make unit tests for engine and aggregating lists
            var artistsIds = likedArtists.Aggregate(string.Empty, (current, artist) => current + "," + artist.id);

            //var tracks = await _spotifyApi.GetRecommendations()
        }

        public void ExportRecommendation()
        {
            throw new NotImplementedException();
        }
    }
}
