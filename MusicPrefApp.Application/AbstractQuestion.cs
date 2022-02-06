using System.Threading.Tasks;

namespace MusicPrefApp.Application
{
    //public abstract class Question1<TOpt, TAns, TPar>
    //{
    //    protected Question1(string description)
    //    {
    //        Description = description;
    //    }

    //    public TAns Answers { get; set; }

    //    public abstract TOpt GetOptions<T>(Func<TPar, TOpt> retrievalFunc, TPar parameters);
    //    //{
    //    //    return retrievalFunc(parameters);
    //    //}

    //    public string Description { get; }
    //}

    public abstract class Question<TIn, TPar>
    {
        public TIn Answers { get; set; }

        public abstract Task<TIn> GetOptions<T>(TPar parameters);
    }

    public abstract class Question<TIn>
    {
        public TIn Answers { get; set; }

        public abstract Task<TIn> GetOptionsAsync<T>();
    }
}