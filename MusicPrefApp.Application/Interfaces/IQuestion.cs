using System.Threading.Tasks;

namespace MusicPrefApp.Application.Interfaces
{
    public interface IQuestion<TIn>
    {
        public string Description { get; set; }

       // public Type Type { get; set; }

        Task<TIn> GetOptionsAsync<T>();
    }

    public interface IQuestion<TIn, TPar>
    {
        public string Description { get; set; }

       // public Type Type { get; set; }

        Task<TIn> GetOptions<T>(TPar parameters);
    }
}
