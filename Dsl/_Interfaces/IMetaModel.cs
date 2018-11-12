namespace CodeGeneration.DSL
{
    using System.Collections.Generic;

    public interface IMetaModel
    { 
        IEnumerable<IClass> Classes { get; }
    }
}
