using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi;
using MusicPrefApp.Services.SpotifyApi.Extensions;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Application.Questions
{
    public class TracksQuestion : Question<List<Track>, List<Artist>>, IQuestion
    {
        private readonly ISpotifyApi _spotifyApi;
        public int Number { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }

        public TracksQuestion(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
            Description = "Which tracks do you like?";
            Number = 4;
            Type = typeof(List<Track>);
        }

        public override async Task<List<Track>> GetOptions<T>(List<Artist> parameters)
        {
            var tracks = new List<Track>();

            foreach (var parameter in parameters)
            {
                var result = await _spotifyApi.GetTracksBasedOnArtist(parameter.name);
                tracks.AddRange(result.tracks.items);
            }

            return tracks;
        }
    }
}
