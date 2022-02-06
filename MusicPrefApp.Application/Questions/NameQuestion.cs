using System;
using System.Threading.Tasks;

namespace MusicPrefApp.Application.Questions
{
    public class NameQuestion : Question<string>, IQuestion
    {
        public NameQuestion()
        {
            Number = 1;
            Description = "What is your name?";
            Type = typeof(string);
        }

        public int Number { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }

        public override async Task<string> GetOptionsAsync<T>()
        {
            return "Please State your name";
        }
    }
}
