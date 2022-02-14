using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Services.SpotifyApi.Extensions
{
    public static class ISpotifyApiExtensions
    {
        public static Task<ArtistsRoot> GetArtistsBasedOnGenre(this ISpotifyApi api, string genre)
        {
            return api.Search<ArtistsRoot>($"genre:{genre}", "artist");
        }

        public static Task<TracksRoot> GetTracksBasedOnArtist(this ISpotifyApi api, string artist)
        {
            return api.Search<TracksRoot>($"artist:{artist}", "track");
        }
    }
}
