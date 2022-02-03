using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi.Models;
using RestEase;

namespace MusicPrefApp.Services.SpotifyApi
{
    public interface ISpotifyApi
    {
        [Get("recommendations/available-genre-seeds")]
        [Header("Content-Type", "application/json")]
        public Task<GenresList> GetGenreSeeds();
    }
}
