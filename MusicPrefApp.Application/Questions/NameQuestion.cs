using System;
using System.Threading.Tasks;
using MusicPrefApp.Application.Interfaces;

namespace MusicPrefApp.Application.Questions
{
    public class NameQuestion : IQuestion<string>
    {
        public NameQuestion()
        {
            Description = "What is your name?";
            //Type = typeof(string);
        }

        public string Description { get; set; }
        //public Type Type { get; set; }

        public Task<string> GetOptionsAsync<T>()
        {
            return Task.FromResult("Please State your name");
        }
    }
}
