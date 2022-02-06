using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPrefApp.Services.SpotifyApi;
using MusicPrefApp.Services.SpotifyApi.Extensions;

namespace MusicPrefApp.Tests.IntegrationTests
{
    [TestClass]
    public class BaseTest
    {
        protected IConfiguration _configuration;
        protected ISpotifyApi _spotifyApi;
        protected MemoryCache _cache;

        [TestInitialize]
        public void InitializeServices()
        {
            var inMemoryConfigurationMock = new Dictionary<string, string> {
                {"SpotifyAuth:Url", "https://accounts.spotify.com"},
                {"SpotifyAuth:ClientId", "be7b547693dc4c38878e5b59b55c9723"},
                {"SpotifyAuth:ClientSecret", "74dc707bfc5e49f9a80c5c8aafc12228"},
                {"SpotifyApi:Url", "https://api.spotify.com/v1"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryConfigurationMock)
                .Build();

            IServiceCollection services = new ServiceCollection();

            _cache = new MemoryCache(new MemoryCacheOptions());

            services.AddSpotifyApiService(_configuration, _cache);
            using var serviceProvider = services.BuildServiceProvider();

            _spotifyApi = serviceProvider.GetRequiredService<ISpotifyApi>();
        }
    }
}
