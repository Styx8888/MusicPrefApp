using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi;

namespace MusicPrefApp.Application.Questions
{

    public class GenreQuestion : Question<List<string>>, IQuestion
    {
        private readonly ISpotifyApi _spotifyApi;
        public int Number { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }

        public GenreQuestion(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
            Description = "What genre of music do you like?";
            Number = 2;
            Type = typeof(List<string>);
        }

        public override async Task<List<string>> GetOptionsAsync<T>()
        {
            var genres = await _spotifyApi.GetGenreSeeds();
            return genres.genres;
        }
    }
}
