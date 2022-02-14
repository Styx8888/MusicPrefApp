using System;
using Microsoft.Extensions.Configuration;
using RestEase;

namespace MusicPrefApp.Services.SpotifyApi
{
    public static class SpotifyAuthApiCreator
    {
        public static ISpotifyAuthApi GetSpotifyAuthApi(IConfiguration configuration)
        {
            //// TODO: move this method
            var authSection = configuration.GetSection("SpotifyAuth");
            if (string.IsNullOrEmpty(authSection["Url"]))
            {
                throw new Exception("Please fill SpotifyAuth section with Url property in the configuration file");
            }

            return RestClient.For<ISpotifyAuthApi>(authSection["Url"]);
        }
    }
}
