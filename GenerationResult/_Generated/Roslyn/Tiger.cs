﻿namespace CodeGeneration.GenerationResult.Roslyn
{
    using System.Collections.Generic;

    public class Tiger
    {
        private IEnumerable<int> preyIds;
        public Tiger(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public int NumberOfLegs => 4;
        public IEnumerable<int> Preys => preyIds ?? (preyIds = new List<int>{2});
    }
}