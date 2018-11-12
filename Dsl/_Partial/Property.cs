namespace CodeGeneration.DSL
{
    internal partial class Property : IProperty
    {
        string IProperty.Name => Name;

        string IProperty.Type => Type;

        string IProperty.DefaultValue => DefaultValue;

        bool IProperty.IsReadOnly => IsReadOnly;
    }
}
