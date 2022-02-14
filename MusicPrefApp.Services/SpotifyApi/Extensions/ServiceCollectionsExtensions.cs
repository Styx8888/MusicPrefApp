using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MusicPrefApp.Services.SpotifyApi.Models;
using RestEase;

namespace MusicPrefApp.Services.SpotifyApi.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddSpotifyApiService(this IServiceCollection services,
            IConfiguration configuration, IMemoryCache cache)
        {
            var spotifySection = configuration.GetSection("SpotifyApi");
            if (string.IsNullOrEmpty(spotifySection["Url"]))
            {
                throw new Exception("Please fill SpotifyApi section with Url property in the configuration file");
            }

            var api = RestClient.For<ISpotifyApi>(spotifySection["Url"], async (request, cancellationToken) =>
            {
                if (!cache.TryGetValue("Token", out TokenModel token))
                {
                    var authApi = SpotifyAuthApiCreator.GetSpotifyAuthApi(configuration);
                    token = await authApi.GetSpotifyToken(configuration);

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(token.expires_in-30));
                    cache.Set("Token", token, cacheEntryOptions);
                }

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            });

            services.AddSingleton(api);

            return services;
        }
    }
}
