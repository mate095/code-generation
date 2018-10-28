namespace CodeGeneration.GenerationResult.Roslyn
{
    public class Buffallo
    {
        public Buffallo(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public int NumberOfLegs => 4;
    }
}