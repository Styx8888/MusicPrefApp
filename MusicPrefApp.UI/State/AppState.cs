using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPrefApp.Services.SpotifyApi.Models;
using MusicPrefApp.UI.Models;

namespace MusicPrefApp.UI.State
{
    public class AppState
    {

        public AppState()
        {
            AnswersModel = new AnswersModel();
        }

        public AnswersModel AnswersModel { get; }

        public event Action OnGenreChanged;

        public event Action OnArtistsChanged;

        public event Action OnTracksChanged;

        public void SetName(string name)
        {
            AnswersModel.Username = name;
        }

        public async Task SetGenres(List<string> genres)
        {
            AnswersModel.SelectedGenres = genres;
            OnGenreChanged?.Invoke();
        }

        public void SetArtists(List<Artist> artists)
        {
            AnswersModel.SelectedArtists = artists;
            OnArtistsChanged?.Invoke();
        }

        public void SetTracks(List<Track> tracks)
        {
            AnswersModel.SelectedTracks = tracks;
            OnTracksChanged?.Invoke();
        }
    }
}
