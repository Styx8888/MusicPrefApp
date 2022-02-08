using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Application.Interfaces
{
    public interface IRecommendationEngine
    {
        Task<List<Track>> GetRecommendations(List<string> likedGenres, List<Artist> likedArtists, List<Track> likedTracks);

        string ExportRecommendation(List<Track> recommendations);
    }
}
