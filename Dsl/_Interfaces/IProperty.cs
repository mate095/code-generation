namespace CodeGeneration.DSL
{

    public interface IProperty
    {
        string Name { get; }

        string Type { get; }

        string DefaultValue { get; }

        bool IsReadOnly { get; }
    }
}
