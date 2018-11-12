namespace CodeGeneration.DSL
{
    using System.Collections.Generic;

    public interface IClass
    {
        string Name { get; }

        IEnumerable<IProperty> Properties { get; }

        IEnumerable<IClass> DerivedClasses { get; }

        IClass BaseClass { get; }
        
    }
}
