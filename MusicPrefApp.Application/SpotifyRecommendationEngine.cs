using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPrefApp.Application.Interfaces;
using MusicPrefApp.Services.SpotifyApi;
using MusicPrefApp.Services.SpotifyApi.Models;
using ServiceStack;

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
            var artistsIds = likedArtists.Select(a => a.id).Aggregate((id1, id2) => id1 + "," + id2);
            var genres = likedGenres.Aggregate((g1, g2) => g1 + "," + g2);
            var trackIds = likedTracks.Select(t => t.id).Aggregate((id1, id2) => id1 + "," + id2);
            var recommendation = await _spotifyApi.GetRecommendations(artistsIds, genres, trackIds);

            return recommendation.tracks.OrderByDescending(x => x.popularity).ToList();
        }

        public string ExportRecommendation(List<Track> recommendations)
        {
            return recommendations.ToCsv();
        }
    }
}
