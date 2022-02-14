using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MusicPrefApp.Services.SpotifyApi.Models;
using RestEase;

namespace MusicPrefApp.Services.SpotifyApi.Extensions
{
    public static class ISpotifyAuthApiExtensions
    {
        public static async Task<TokenModel> GetSpotifyToken(this ISpotifyAuthApi api, IConfiguration configuration)
        {
            var authSection = configuration.GetSection("SpotifyAuth");
            if (string.IsNullOrEmpty(authSection["ClientId"]) || string.IsNullOrEmpty(authSection["ClientSecret"]))
            {
                throw new Exception("Please fill SpotifyAuth section with ClientId and ClientSecret property in the configuration file");
            }
            var headerValue =
                $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{authSection["ClientId"]}:{authSection["ClientSecret"]}"))}";
            var requestData = new Dictionary<string, object> {
                {"grant_type", "client_credentials"}
            };
            return await api.GetTokenAsync(headerValue, requestData);
        }
    }
}
