namespace CodeGeneration.TestDataCreator
{
    using CodeGeneration.DSL;
    using Microsoft.VisualStudio.Modeling;
    using System;

    /// <summary>
    /// Class for creat test data for code generation
    /// </summary>
    public class TestDataCreator : IDisposable
    {
        Store store;

        public IMetaModel CreatMetaModel()
        {
            store = new Store(typeof(DSLDomainModel));
            MetaModel metaModel;
            using (Transaction t = store.TransactionManager.BeginTransaction("Create test meta model"))
            {
                metaModel = new MetaModel(store);

                Property nameProperty = new Property(store)
                {
                    Name = "Name",
                    Type = "string",
                    IsReadOnly = true
                    
                };

                Property ageProperty = new Property(store)
                {
                    Name = "Age",
                    Type = "int"
                };
                

                Class personClass = new Class(store)
                {
                    Name = "Person",
                };

                personClass.Properties.Add(nameProperty);
                personClass.Properties.Add(ageProperty);

                Class studentClass = new Class(store)
                {
                    Name = "Student",
                    BaseClass = personClass
                };

                Property neptunProperty = new Property(store)
                {
                    Name = "NeptunCode",
                    Type = "string",
                    IsReadOnly = true

                };

                Property kreditProperty = new Property(store)
                {
                    Name = "Kredits",
                    Type = "int",
                    DefaultValue = "0"
                };

                studentClass.Properties.Add(neptunProperty);
                studentClass.Properties.Add(kreditProperty);

                metaModel.Classes.Add(personClass);
                metaModel.Classes.Add(studentClass);

                t.Commit();
            }

            return metaModel;
        }

        public void Dispose()
        {
            store.Dispose();
        }
    }
}
