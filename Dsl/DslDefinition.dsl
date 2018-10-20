<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="94499fe6-1707-4dd5-a16d-ca6d21e9734a" Description="Description for CodeGeneration.DSL.DSL" Name="DSL" DisplayName="DSL" Namespace="CodeGeneration.DSL" ProductName="CodeGeneration" PackageGuid="47ca2df8-e553-45a3-b4e8-5a49bba3c66f" PackageNamespace="CodeGeneration.DSL" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="0d2d00d2-b723-48f3-b9b7-c964f2154b03" Description="The root in which all other elements are embedded. Appears as a diagram." Name="World" DisplayName="World" AccessModifier="Assembly" Namespace="CodeGeneration.DSL">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Notes>Creates an embedding link when an element is dropped onto a model. </Notes>
          <Index>
            <DomainClassMoniker Name="Animal" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>WorldHasAnimals.Animals</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="7d59e46a-9b6c-46d3-a922-8e8beb2bbf41" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="Animal" DisplayName="Animal" AccessModifier="Assembly" Namespace="CodeGeneration.DSL">
      <Properties>
        <DomainProperty Id="389f8079-5dd5-4306-8f02-cb7541144e08" Description="Description for CodeGeneration.DSL.Animal.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="faceaa50-72a5-4ebb-bc95-66c6e59e5fab" Description="Embedding relationship between the Model and Elements" Name="WorldHasAnimals" DisplayName="World Has Animals" Namespace="CodeGeneration.DSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="9a4fa787-c83c-44a5-9207-ed011a45e911" Description="" Name="World" DisplayName="World" PropertyName="Animals" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Animals">
          <RolePlayer>
            <DomainClassMoniker Name="World" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="3224416b-0762-4a1a-99a1-e8a28c02b46c" Description="" Name="Element" DisplayName="Element" PropertyName="World" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="World">
          <RolePlayer>
            <DomainClassMoniker Name="Animal" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <XmlSerializationBehavior Name="DSLSerializationBehavior" Namespace="CodeGeneration.DSL">
    <ClassData>
      <XmlClassData TypeName="World" MonikerAttributeName="" SerializeId="true" MonikerElementName="worldMoniker" ElementName="world" MonikerTypeName="WorldMoniker">
        <DomainClassMoniker Name="World" />
        <ElementData>
          <XmlRelationshipData RoleElementName="animals">
            <DomainRelationshipMoniker Name="WorldHasAnimals" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Animal" MonikerAttributeName="name" SerializeId="true" MonikerElementName="animalMoniker" ElementName="animal" MonikerTypeName="AnimalMoniker">
        <DomainClassMoniker Name="Animal" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Animal/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="WorldHasAnimals" MonikerAttributeName="" SerializeId="true" MonikerElementName="worldHasAnimalsMoniker" ElementName="worldHasAnimals" MonikerTypeName="WorldHasAnimalsMoniker">
        <DomainRelationshipMoniker Name="WorldHasAnimals" />
      </XmlClassData>
      <XmlClassData TypeName="DSLDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="dSLDiagramMoniker" ElementName="dSLDiagram" MonikerTypeName="DSLDiagramMoniker">
        <DiagramMoniker Name="DSLDiagram" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="DSLExplorer" />
  <Diagram Id="4709a42c-6ff6-4595-9ea1-c18913b762f9" Description="Description for CodeGeneration.DSL.DSLDiagram" Name="DSLDiagram" DisplayName="Minimal Language Diagram" Namespace="CodeGeneration.DSL">
    <Class>
      <DomainClassMoniker Name="World" />
    </Class>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="model" EditorGuid="6efc3e1d-65d4-41b8-8e36-f6ae4ac5cce7">
    <RootClass>
      <DomainClassMoniker Name="World" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="DSLSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="DSL">
      <ElementTool Name="ExampleElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="ExampleElement" Tooltip="Create an ExampleElement" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="Animal" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="DSLDiagram" />
  </Designer>
  <Explorer ExplorerGuid="aa89f8f3-fdbc-4e6b-b8a7-85151cd909ed" Title="DSL Explorer">
    <ExplorerBehaviorMoniker Name="DSL/DSLExplorer" />
  </Explorer>
</Dsl>