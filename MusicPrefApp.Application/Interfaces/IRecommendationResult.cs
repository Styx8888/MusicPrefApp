namespace MusicPrefApp.Application.Interfaces
{
    public interface IRecommendationResult<T>
    {
        T Recommendations { get; set; }
    }
}
