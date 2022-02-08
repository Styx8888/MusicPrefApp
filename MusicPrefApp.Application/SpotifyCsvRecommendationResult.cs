using MusicPrefApp.Application.Interfaces;

namespace MusicPrefApp.Application
{
    public class SpotifyCsvRecommendationResult : IRecommendationResult<string>
    {
        public string Recommendations { get; set; }
    }
}
