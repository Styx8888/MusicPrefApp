using System;

namespace MusicPrefApp.Application
{
    public interface IQuestion
    {
        public int Number { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }
    }
}
