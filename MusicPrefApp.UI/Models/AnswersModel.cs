using System.Collections.Generic;
using FluentValidation;
using MusicPrefApp.Services.SpotifyApi.Models;

namespace MusicPrefApp.UI.Models
{
    public class AnswersModelValidator : AbstractValidator<AnswersModel>
    {
        public AnswersModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.SelectedGenres).NotEmpty();
            RuleFor(x => x.SelectedArtists).NotEmpty();
            RuleFor(x => x.SelectedTracks).NotEmpty();
            RuleFor(x => new {x.SelectedArtists, x.SelectedGenres, x.SelectedTracks})
                .Must(x => x.SelectedArtists.Count + x.SelectedGenres.Count + x.SelectedTracks.Count <= 5)
                .WithMessage("Number of total selected items cannot exceed 5");
        }
    }

    public class AnswersModel
    {
        public string Username { get; set; }

        public List<string> SelectedGenres { get; set; } = new List<string>();

        public List<Artist> SelectedArtists { get; set; } = new List<Artist>();

        public List<Track> SelectedTracks { get; set; } = new List<Track>();
    }
}
