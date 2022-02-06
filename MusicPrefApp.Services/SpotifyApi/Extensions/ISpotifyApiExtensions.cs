using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.Services.SpotifyApi.Extensions
{
    public static class ISpotifyApiExtensions
    {
        public static async Task<ArtistsRoot> GetArtistsBasedOnGenre(this ISpotifyApi api, string genre)
        {
            return await api.Search<ArtistsRoot>($"genre:{genre}", "artist");
        }

        public static async Task<TracksRoot> GetTracksBasedOnArtist(this ISpotifyApi api, string artist)
        {
            return await api.Search<TracksRoot>($"artist:{artist}", "track");
        }
    }
}
