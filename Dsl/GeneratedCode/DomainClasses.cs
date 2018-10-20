﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
namespace CodeGeneration.DSL
{
	/// <summary>
	/// DomainClass World
	/// The root in which all other elements are embedded. Appears as a diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("CodeGeneration.DSL.World.DisplayName", typeof(global::CodeGeneration.DSL.DSLDomainModel), "CodeGeneration.DSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("CodeGeneration.DSL.World.Description", typeof(global::CodeGeneration.DSL.DSLDomainModel), "CodeGeneration.DSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::CodeGeneration.DSL.DSLDomainModel))]
	[DslModeling::DomainObjectId("0d2d00d2-b723-48f3-b9b7-c964f2154b03")]
	internal partial class World : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// World domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x0d2d00d2, 0xb723, 0x48f3, 0xb9, 0xb7, 0xc9, 0x64, 0xf2, 0x15, 0x4b, 0x03);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public World(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public World(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Animals opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Animals.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Animal> Animals
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Animal>, Animal>(global::CodeGeneration.DSL.WorldHasAnimals.WorldDomainRoleId);
			}
		}
		#endregion
		#region ElementGroupPrototype Merge methods
		/// <summary>
		/// Returns a value indicating whether the source element represented by the
		/// specified root ProtoElement can be added to this element.
		/// </summary>
		/// <param name="rootElement">
		/// The root ProtoElement representing a source element.  This can be null, 
		/// in which case the ElementGroupPrototype does not contain an ProtoElements
		/// and the code should inspect the ElementGroupPrototype context information.
		/// </param>
		/// <param name="elementGroupPrototype">The ElementGroupPrototype that contains the root ProtoElement.</param>
		/// <returns>true if the source element represented by the ProtoElement can be added to this target element.</returns>
		protected override bool CanMerge(DslModeling::ProtoElementBase rootElement, DslModeling::ElementGroupPrototype elementGroupPrototype)
		{
			if ( elementGroupPrototype == null ) throw new global::System.ArgumentNullException("elementGroupPrototype");
			
			if (rootElement != null)
			{
				DslModeling::DomainClassInfo rootElementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(rootElement.DomainClassId);
				
				if (rootElementDomainInfo.IsDerivedFrom(global::CodeGeneration.DSL.Animal.DomainClassId)) 
				{
					return true;
				}
			}
			return base.CanMerge(rootElement, elementGroupPrototype);
		}
		
		/// <summary>
		/// Called by the Merge process to create a relationship between 
		/// this target element and the specified source element. 
		/// Typically, a parent-child relationship is established
		/// between the target element (the parent) and the source element 
		/// (the child), but any relationship can be established.
		/// </summary>
		/// <param name="sourceElement">The element that is to be related to this model element.</param>
		/// <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
		/// <remarks>
		/// This method is overriden to create the relationship between the target element and the specified source element.
		/// The base method does nothing.
		/// </remarks>
		protected override void MergeRelate(DslModeling::ModelElement sourceElement, DslModeling::ElementGroup elementGroup)
		{
			// In general, sourceElement is allowed to be null, meaning that the elementGroup must be parsed for special cases.
			// However this is not supported in generated code.  Use double-deriving on this class and then override MergeRelate completely if you 
			// need to support this case.
			if ( sourceElement == null ) throw new global::System.ArgumentNullException("sourceElement");
		
				
			global::CodeGeneration.DSL.Animal sourceAnimal1 = sourceElement as global::CodeGeneration.DSL.Animal;
			if (sourceAnimal1 != null)
			{
				// Create link for path WorldHasAnimals.Animals
				this.Animals.Add(sourceAnimal1);

				return;
			}
		
			// Sdk workaround to runtime bug #879350 (DSL: can't copy and paste a MEL that has a MEX). Avoid MergeRelate on ModelElementExtension
			// during a "Paste".
			if (sourceElement is DslModeling::ExtensionElement
				&& sourceElement.Store.TransactionManager.CurrentTransaction.TopLevelTransaction.Context.ContextInfo.ContainsKey("{9DAFD42A-DC0E-4d78-8C3F-8266B2CF8B33}"))
			{
				return;
			}
		
			// Fall through to base class if this class hasn't handled the merge.
			base.MergeRelate(sourceElement, elementGroup);
		}
		
		/// <summary>
		/// Performs operation opposite to MergeRelate - i.e. disconnects a given
		/// element from the current one (removes links created by MergeRelate).
		/// </summary>
		/// <param name="sourceElement">Element to be unmerged/disconnected.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		protected override void MergeDisconnect(DslModeling::ModelElement sourceElement)
		{
			if (sourceElement == null) throw new global::System.ArgumentNullException("sourceElement");
				
			global::CodeGeneration.DSL.Animal sourceAnimal1 = sourceElement as global::CodeGeneration.DSL.Animal;
			if (sourceAnimal1 != null)
			{
				// Delete link for path WorldHasAnimals.Animals
				
				foreach (DslModeling::ElementLink link in global::CodeGeneration.DSL.WorldHasAnimals.GetLinks((global::CodeGeneration.DSL.World)this, sourceAnimal1))
				{
					// Delete the link, but without possible delete propagation to the element since it's moving to a new location.
					link.Delete(global::CodeGeneration.DSL.WorldHasAnimals.WorldDomainRoleId, global::CodeGeneration.DSL.WorldHasAnimals.ElementDomainRoleId);
				}

				return;
			}
			// Fall through to base class if this class hasn't handled the unmerge.
			base.MergeDisconnect(sourceElement);
		}
		#endregion
	}
}
namespace CodeGeneration.DSL
{
	/// <summary>
	/// DomainClass Animal
	/// Elements embedded in the model. Appear as boxes on the diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("CodeGeneration.DSL.Animal.DisplayName", typeof(global::CodeGeneration.DSL.DSLDomainModel), "CodeGeneration.DSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("CodeGeneration.DSL.Animal.Description", typeof(global::CodeGeneration.DSL.DSLDomainModel), "CodeGeneration.DSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::CodeGeneration.DSL.DSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("7d59e46a-9b6c-46d3-a922-8e8beb2bbf41")]
	internal partial class Animal : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Animal domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x7d59e46a, 0x9b6c, 0x46d3, 0xa9, 0x22, 0x8e, 0x8b, 0xeb, 0x2b, 0xbf, 0x41);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Animal(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Animal(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new global::System.Guid(0x389f8079, 0x5dd5, 0x4306, 0x8f, 0x02, 0xcb, 0x75, 0x41, 0x14, 0x4e, 0x08);
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = string.Empty;
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// Description for CodeGeneration.DSL.Animal.Name
		/// </summary>
		[DslDesign::DisplayNameResource("CodeGeneration.DSL.Animal/Name.DisplayName", typeof(global::CodeGeneration.DSL.DSLDomainModel), "CodeGeneration.DSL.GeneratedCode.DomainModelResx")]
		[DslDesign::DescriptionResource("CodeGeneration.DSL.Animal/Name.Description", typeof(global::CodeGeneration.DSL.DSLDomainModel), "CodeGeneration.DSL.GeneratedCode.DomainModelResx")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("389f8079-5dd5-4306-8f02-cb7541144e08")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Animal.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Animal, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Animal.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Animal.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(Animal element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Animal element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region World opposite domain role accessor
		/// <summary>
		/// Gets or sets World.
		/// </summary>
		internal virtual World World
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::CodeGeneration.DSL.WorldHasAnimals.ElementDomainRoleId) as World;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::CodeGeneration.DSL.WorldHasAnimals.ElementDomainRoleId, value);
			}
		}
		#endregion
	}
}