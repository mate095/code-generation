namespace CodeGeneration.Generator.Logic
{
    using CodeGeneration.DSL;
    using System.Collections.Generic;
    using System.Linq;

    public class ClassTemplateData
    {
        private IClass classMeta;

        public ClassTemplateData(IClass classMeta)
        {
            this.classMeta = classMeta;
        }

        public string Name => classMeta.Name;

        public string InterfaceName => $"I{classMeta.Name}";

        public string BaseClassName => classMeta.BaseClass?.Name ;

        public bool HasBase => classMeta.BaseClass != null;

        public IEnumerable<PropertyTemplateData> ReadOnlyPropertiesWithDefaultValue => 
            classMeta.Properties.Where(x => x.IsReadOnly && !x.DefaultValue.Equals("")).Select(y => new PropertyTemplateData(y));

        public IEnumerable<PropertyTemplateData> ReadOnlyPropertiesWithOutDefaultValue =>
            classMeta.Properties.Where(x => x.IsReadOnly && x.DefaultValue.Equals("")).Select(y => new PropertyTemplateData(y));

        public IEnumerable<PropertyTemplateData> PropertiesWithSetter =>
            classMeta.Properties.Where(x => !x.IsReadOnly).Select(y => new PropertyTemplateData(y));

        public IEnumerable<PropertyTemplateData> BeseReadOnlyPropertiesWithOutDefaultValue
        {
            get
            {
                if (classMeta.BaseClass != null)
                {
                    return classMeta.BaseClass.Properties.Where(x => x.IsReadOnly && x.DefaultValue.Equals("")).Select(y => new PropertyTemplateData(y));
                }

                return new List<PropertyTemplateData>();
            }
        }
            
        public IEnumerable<PropertyTemplateData> ConstructorParamters =>
            ReadOnlyPropertiesWithOutDefaultValue.Union(BeseReadOnlyPropertiesWithOutDefaultValue);
    }
}
