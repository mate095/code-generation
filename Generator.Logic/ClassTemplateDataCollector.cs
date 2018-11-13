namespace CodeGeneration.Generator.Logic
{
    using CodeGeneration.DSL;
    using CodeGeneration.TestDataCreator;
    using System.Collections.Generic;
    using System.Linq;

    public class ClassTemplateDataCollector
    {
        private IMetaModel metaModel;

        public ClassTemplateDataCollector()
        {
            metaModel = new TestDataCreator().CreatMetaModel();
        }

        public IEnumerable<ClassTemplateData> ClassTemplates => metaModel.Classes.Select(x => new ClassTemplateData(x));

        public IEnumerable<InterfaceTemplateData> InterfaceTemplates => metaModel.Classes.Select(x => new InterfaceTemplateData(x));
    }
}
