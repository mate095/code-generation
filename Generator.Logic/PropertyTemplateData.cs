namespace CodeGeneration.Generator.Logic
{
    using CodeGeneration.DSL;

    public class PropertyTemplateData
    {
        private IProperty propertyMeta;

        public PropertyTemplateData(IProperty propertyMeta)
        {
            this.propertyMeta = propertyMeta;
        }

        public string Name => propertyMeta.Name;

        public string NameStartWithLowerCase
        {
            get
            {
                var firstChar = propertyMeta.Name.Substring(0, 1);
                firstChar = firstChar.ToLower();

                return $"{firstChar}{propertyMeta.Name.Remove(0, 1)}";
            }
        }

        public string Type => propertyMeta.Type;

        public string DefaultValue => propertyMeta.DefaultValue;

        public bool IsReadOnly => propertyMeta.IsReadOnly;
    }
}
