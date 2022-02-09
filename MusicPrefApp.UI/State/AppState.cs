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

        public event Action OnClear;

        public void SetName(string name)
        {
            AnswersModel.Username = name;
        }

        public void ClearAll()
        {
            AnswersModel.Username = string.Empty;
            AnswersModel.SelectedTracks.Clear();
            //OnTracksChanged?.Invoke();
            AnswersModel.SelectedArtists.Clear();
            //OnArtistsChanged?.Invoke();
            AnswersModel.SelectedGenres.Clear();
            // OnGenreChanged?.Invoke();
            OnClear?.Invoke();
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
