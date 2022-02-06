using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi;

namespace MusicPrefApp.Application.Questions
{

    public class GenreQuestion : Question<List<string>>
    {
        private readonly ISpotifyApi _spotifyApi;

        public GenreQuestion(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
            Description = "What genre of music do you like?";
            Number = 1;
        }

        public override async Task<List<string>> GetOptionsAsync<T>()
        {
            var genres = await _spotifyApi.GetGenreSeeds();
            return genres.genres;
        }

        
    }
}
