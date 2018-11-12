<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="94499fe6-1707-4dd5-a16d-ca6d21e9734a" Description="Description for CodeGeneration.DSL.DSL" Name="DSL" DisplayName="DSL" Namespace="CodeGeneration.DSL" ProductName="CodeGeneration" PackageGuid="47ca2df8-e553-45a3-b4e8-5a49bba3c66f" PackageNamespace="CodeGeneration.DSL" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="0d2d00d2-b723-48f3-b9b7-c964f2154b03" Description="The root in which all other elements are embedded. Appears as a diagram." Name="MetaModel" DisplayName="Meta Model" AccessModifier="Assembly" Namespace="CodeGeneration.DSL">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Notes>Creates an embedding link when an element is dropped onto a model. </Notes>
          <Index>
            <DomainClassMoniker Name="Class" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasClasses.Classes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="7d59e46a-9b6c-46d3-a922-8e8beb2bbf41" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="Class" DisplayName="Class" AccessModifier="Assembly" Namespace="CodeGeneration.DSL">
      <Properties>
        <DomainProperty Id="389f8079-5dd5-4306-8f02-cb7541144e08" Description="Description for CodeGeneration.DSL.Class.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Property" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ClassHasProperties.Properties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="cfe64160-4698-45a4-bc29-463614104246" Description="Description for CodeGeneration.DSL.Property" Name="Property" DisplayName="Property" AccessModifier="Assembly" Namespace="CodeGeneration.DSL">
      <Properties>
        <DomainProperty Id="14c92785-8e95-46c0-ac72-bd3a0dcd88ac" Description="Description for CodeGeneration.DSL.Property.Name" Name="Name" DisplayName="Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="5de8497d-0f69-427d-8f2b-4495477082fd" Description="Description for CodeGeneration.DSL.Property.Type" Name="Type" DisplayName="Type">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7ffbb7b5-d5d4-468b-9f11-b0c983d06817" Description="Description for CodeGeneration.DSL.Property.Is Read Only" Name="IsReadOnly" DisplayName="Is Read Only" DefaultValue="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="bf19867d-a3d5-47b2-92b1-f03bc2a775cb" Description="Description for CodeGeneration.DSL.Property.Default Value" Name="DefaultValue" DisplayName="Default Value">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="faceaa50-72a5-4ebb-bc95-66c6e59e5fab" Description="Embedding relationship between the Model and Elements" Name="MetaModelHasClasses" DisplayName="Meta Model Has Classes" Namespace="CodeGeneration.DSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="9a4fa787-c83c-44a5-9207-ed011a45e911" Description="" Name="MetaModel" DisplayName="Meta Model" PropertyName="Classes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Classes">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="3224416b-0762-4a1a-99a1-e8a28c02b46c" Description="" Name="Element" DisplayName="Element" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="Class" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7f4d6c55-ee74-4a7f-a8cf-60cbdc80287b" Description="Description for CodeGeneration.DSL.ClassHasProperties" Name="ClassHasProperties" DisplayName="Class Has Properties" Namespace="CodeGeneration.DSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="076be4b8-8650-4014-a6e6-2f9cb0ce3934" Description="Description for CodeGeneration.DSL.ClassHasProperties.Class" Name="Class" DisplayName="Class" PropertyName="Properties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Properties">
          <RolePlayer>
            <DomainClassMoniker Name="Class" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c033081f-5eb4-4ed5-80da-ffac2245f43c" Description="Description for CodeGeneration.DSL.ClassHasProperties.Property" Name="Property" DisplayName="Property" PropertyName="Class" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Class">
          <RolePlayer>
            <DomainClassMoniker Name="Property" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="5f8c5fdd-9a1c-4502-9d54-c67e234d523b" Description="Description for CodeGeneration.DSL.ClassReferencesDerivedClasses" Name="ClassReferencesDerivedClasses" DisplayName="Class References Derived Classes" Namespace="CodeGeneration.DSL">
      <Source>
        <DomainRole Id="cdd3d215-c735-4e70-8432-0aa641e19f6b" Description="Description for CodeGeneration.DSL.ClassReferencesDerivedClasses.SourceClass" Name="SourceClass" DisplayName="Source Class" PropertyName="DerivedClasses" PropertyDisplayName="Derived Classes">
          <RolePlayer>
            <DomainClassMoniker Name="Class" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="526c18de-e3e0-4426-8f71-7169ef2a6269" Description="Description for CodeGeneration.DSL.ClassReferencesDerivedClasses.TargetClass" Name="TargetClass" DisplayName="Target Class" PropertyName="BaseClass" Multiplicity="ZeroOne" PropertyDisplayName="Base Class">
          <RolePlayer>
            <DomainClassMoniker Name="Class" />
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
      <XmlClassData TypeName="MetaModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelMoniker" ElementName="metaModel" MonikerTypeName="MetaModelMoniker">
        <DomainClassMoniker Name="MetaModel" />
        <ElementData>
          <XmlRelationshipData RoleElementName="classes">
            <DomainRelationshipMoniker Name="MetaModelHasClasses" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Class" MonikerAttributeName="name" SerializeId="true" MonikerElementName="classMoniker" ElementName="class" MonikerTypeName="ClassMoniker">
        <DomainClassMoniker Name="Class" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Class/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="properties">
            <DomainRelationshipMoniker Name="ClassHasProperties" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="derivedClasses">
            <DomainRelationshipMoniker Name="ClassReferencesDerivedClasses" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelHasClassesMoniker" ElementName="metaModelHasClasses" MonikerTypeName="MetaModelHasClassesMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasClasses" />
      </XmlClassData>
      <XmlClassData TypeName="DSLDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="dSLDiagramMoniker" ElementName="dSLDiagram" MonikerTypeName="DSLDiagramMoniker">
        <DiagramMoniker Name="DSLDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Property" MonikerAttributeName="" SerializeId="true" MonikerElementName="propertyMoniker" ElementName="property" MonikerTypeName="PropertyMoniker">
        <DomainClassMoniker Name="Property" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="Property/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="type">
            <DomainPropertyMoniker Name="Property/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isReadOnly">
            <DomainPropertyMoniker Name="Property/IsReadOnly" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="defaultValue">
            <DomainPropertyMoniker Name="Property/DefaultValue" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ClassHasProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="classHasPropertiesMoniker" ElementName="classHasProperties" MonikerTypeName="ClassHasPropertiesMoniker">
        <DomainRelationshipMoniker Name="ClassHasProperties" />
      </XmlClassData>
      <XmlClassData TypeName="ClassReferencesDerivedClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="classReferencesDerivedClassesMoniker" ElementName="classReferencesDerivedClasses" MonikerTypeName="ClassReferencesDerivedClassesMoniker">
        <DomainRelationshipMoniker Name="ClassReferencesDerivedClasses" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="DSLExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="ClassReferencesDerivedClassesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ClassReferencesDerivedClasses" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Class" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Class" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="4709a42c-6ff6-4595-9ea1-c18913b762f9" Description="Description for CodeGeneration.DSL.DSLDiagram" Name="DSLDiagram" DisplayName="Minimal Language Diagram" Namespace="CodeGeneration.DSL">
    <Class>
      <DomainClassMoniker Name="MetaModel" />
    </Class>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="model" EditorGuid="6efc3e1d-65d4-41b8-8e36-f6ae4ac5cce7">
    <RootClass>
      <DomainClassMoniker Name="MetaModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="DSLSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="DSL">
      <ElementTool Name="ExampleElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="ExampleElement" Tooltip="Create an ExampleElement" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="Class" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="DSLDiagram" />
  </Designer>
  <Explorer ExplorerGuid="aa89f8f3-fdbc-4e6b-b8a7-85151cd909ed" Title="DSL Explorer">
    <ExplorerBehaviorMoniker Name="DSL/DSLExplorer" />
  </Explorer>
</Dsl>