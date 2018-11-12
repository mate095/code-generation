using System.Collections.Generic;

namespace CodeGeneration.DSL
{
    internal partial class MetaModel : IMetaModel
    {
        IEnumerable<IClass> IMetaModel.Classes => Classes;
    }
}
