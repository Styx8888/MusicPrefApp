using System.Collections.Generic;
using MusicPrefApp.Services.SpotifyApi.Models;
using RestEase;
using System.Threading.Tasks;

namespace MusicPrefApp.Services.SpotifyApi
{
    public interface ISpotifyAuthApi
    {
        [Post("/api/token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<TokenModel> GetTokenAsync([Header("Authorization")] string authorization, [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> request);
    }
}
