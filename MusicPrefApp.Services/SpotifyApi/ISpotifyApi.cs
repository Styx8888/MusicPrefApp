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

        [Get("markets")]
        [Header("Content-Type", "application/json")]
        public Task<MarketsList> GetMarketsList();
            
        [Get("search")]
        [Header("Content-Type", "application/json")]
        public Task<T> Search<T>([Query("q")] string query, [Query("type")] string types, [Query("limit")] int limit=20, [Query("offset")] int offset=0);

        [Get("recommendations")]
        [Header("Content-Type", "application/json")]
        [Header("Accept", "application/json")]
        public Task<RecommendationRoot> GetRecommendations([Query("seed_artists")] string artistsIds,
            [Query("seed_genres")] string genres, [Query("seed_tracks")] string tracksId,
            [Query("limit")] int limit = 10);
    }
}
