using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Application.Interfaces;
using MusicPrefApp.Services.SpotifyApi;
using MusicPrefApp.Services.SpotifyApi.Extensions;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Application.Questions
{
    public class TracksQuestion : IQuestion<List<Track>, List<Artist>>
    {
        private readonly ISpotifyApi _spotifyApi;
        public string Description { get; set; }
        //public Type Type { get; set; }

        public TracksQuestion(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
            Description = "Which tracks do you like?";
            //Type = typeof(List<Track>);
        }

        public async Task<List<Track>> GetOptions<T>(List<Artist> parameters)
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
