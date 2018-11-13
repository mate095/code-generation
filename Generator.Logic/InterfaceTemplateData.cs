

namespace CodeGeneration.Generator.Logic
{
    using CodeGeneration.DSL;
    using System.Collections.Generic;
    using System.Linq;

    public class InterfaceTemplateData
    {
        private IClass classMeta;
        private List<PropertyTemplateData> properties;

        public InterfaceTemplateData(IClass classMeta)
        {
            this.classMeta = classMeta;
        }

        public string Name => $"I{classMeta.Name}";

        public IEnumerable<PropertyTemplateData> Properties
        {
            get
            {
                if(properties == null)
                {
                    properties = new List<PropertyTemplateData>();
                    properties.AddRange(classMeta.Properties.Select(x => new PropertyTemplateData(x)));

                    if (classMeta.BaseClass != null)
                    {
                        properties.AddRange(classMeta.BaseClass.Properties.Select(x => new PropertyTemplateData(x)));
                    }
                }

                return properties;
            }
        }
    }
}
