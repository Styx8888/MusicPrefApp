using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Application.Interfaces;
using MusicPrefApp.Services.SpotifyApi;

namespace MusicPrefApp.Application.Questions
{

    public class GenreQuestion : IQuestion<List<string>>
    {
        private readonly ISpotifyApi _spotifyApi;
        public string Description { get; set; }
       // public Type Type { get; set; }

        public GenreQuestion(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
            Description = "What genre of music do you like?";
           // Type = typeof(List<string>);
        }

        public async Task<List<string>> GetOptionsAsync<T>()
        {
            var genres = await _spotifyApi.GetGenreSeeds();
            return genres.genres;
        }
    }
}
