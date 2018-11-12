using System.Collections.Generic;

namespace CodeGeneration.DSL
{
    internal partial class Class : IClass
    {
        string IClass.Name => Name;

        IEnumerable<IProperty> IClass.Properties => Properties;

        IEnumerable<IClass> IClass.DerivedClasses => DerivedClasses;

        IClass IClass.BaseClass => BaseClass;
    }
}
