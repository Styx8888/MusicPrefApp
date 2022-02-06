using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi;
using MusicPrefApp.Services.SpotifyApi.Extensions;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Application.Questions
{
    public class ArtistsQuestion : Question<List<Artist>, List<string>>, IQuestion
    {
        private readonly ISpotifyApi _spotifyApi;
        public int Number { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }

        public ArtistsQuestion(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
            Description = "Which Artist from the list do you like?";
            Number = 3;
            Type = typeof(List<Artist>);
        }

        public override async Task<List<Artist>> GetOptions<T>(List<string> parameters)
        {
            var artists = new List<Artist>();

            var crossGenreString = string.Join(",", parameters);
            var crossGenreList = await _spotifyApi.GetArtistsBasedOnGenre(crossGenreString);
            artists.AddRange(crossGenreList.artists.items);

            foreach (var parameter in parameters)
            {
                var oneGenreList = await _spotifyApi.GetArtistsBasedOnGenre(parameter);
                artists.AddRange(oneGenreList.artists.items);
            }

            return artists.Distinct().ToList();
        }
    }
}
