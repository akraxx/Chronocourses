﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chronocourses.Manager.EntityService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ExtendedPropertiesDictionary", Namespace="http://schemas.datacontract.org/2004/07/Chronocourses.Model", ItemName="ExtendedProperties", KeyName="Name", ValueName="ExtendedProperty")]
    [System.SerializableAttribute()]
    public class ExtendedPropertiesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsAddedToCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/Chronocourses.Model", ItemName="AddedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="AddedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, Chronocourses.Manager.EntityService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectList", Namespace="http://schemas.datacontract.org/2004/07/Chronocourses.Model", ItemName="ObjectValue")]
    [System.SerializableAttribute()]
    public class ObjectList : System.Collections.Generic.List<object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsRemovedFromCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/Chronocourses.Model", ItemName="DeletedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="DeletedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, Chronocourses.Manager.EntityService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/Chronocourses.Model", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    [System.SerializableAttribute()]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EntityService.IEntityService")]
    public interface IEntityService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/GetEntitys", ReplyAction="http://tempuri.org/IEntityService/GetEntitysResponse")]
        Chronocourses.Model.Entity[] GetEntitys();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/addProductToContainer", ReplyAction="http://tempuri.org/IEntityService/addProductToContainerResponse")]
        int addProductToContainer(Chronocourses.Model.Product product, Chronocourses.Model.Entity ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/RemoveProductFromContainer", ReplyAction="http://tempuri.org/IEntityService/RemoveProductFromContainerResponse")]
        int RemoveProductFromContainer(Chronocourses.Model.Product product, Chronocourses.Model.Entity ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/RemoveAllProductsFromContainer", ReplyAction="http://tempuri.org/IEntityService/RemoveAllProductsFromContainerResponse")]
        int RemoveAllProductsFromContainer(Chronocourses.Model.Entity ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/setContainer", ReplyAction="http://tempuri.org/IEntityService/setContainerResponse")]
        int setContainer(Chronocourses.Model.Entity ent, bool container);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/GetEntity", ReplyAction="http://tempuri.org/IEntityService/GetEntityResponse")]
        Chronocourses.Model.Entity GetEntity(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/SaveEntity", ReplyAction="http://tempuri.org/IEntityService/SaveEntityResponse")]
        void SaveEntity(Chronocourses.Model.Entity Entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/AddEntity", ReplyAction="http://tempuri.org/IEntityService/AddEntityResponse")]
        int AddEntity(Chronocourses.Model.Entity Entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/DeleteEntity", ReplyAction="http://tempuri.org/IEntityService/DeleteEntityResponse")]
        int DeleteEntity(Chronocourses.Model.Entity Entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEntityService/SaveEntitys", ReplyAction="http://tempuri.org/IEntityService/SaveEntitysResponse")]
        void SaveEntitys();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEntityServiceChannel : Chronocourses.Manager.EntityService.IEntityService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EntityServiceClient : System.ServiceModel.ClientBase<Chronocourses.Manager.EntityService.IEntityService>, Chronocourses.Manager.EntityService.IEntityService {
        
        public EntityServiceClient() {
        }
        
        public EntityServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EntityServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EntityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EntityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Chronocourses.Model.Entity[] GetEntitys() {
            return base.Channel.GetEntitys();
        }
        
        public int addProductToContainer(Chronocourses.Model.Product product, Chronocourses.Model.Entity ent) {
            return base.Channel.addProductToContainer(product, ent);
        }
        
        public int RemoveProductFromContainer(Chronocourses.Model.Product product, Chronocourses.Model.Entity ent) {
            return base.Channel.RemoveProductFromContainer(product, ent);
        }
        
        public int RemoveAllProductsFromContainer(Chronocourses.Model.Entity ent) {
            return base.Channel.RemoveAllProductsFromContainer(ent);
        }
        
        public int setContainer(Chronocourses.Model.Entity ent, bool container) {
            return base.Channel.setContainer(ent, container);
        }
        
        public Chronocourses.Model.Entity GetEntity(int id) {
            return base.Channel.GetEntity(id);
        }
        
        public void SaveEntity(Chronocourses.Model.Entity Entity) {
            base.Channel.SaveEntity(Entity);
        }
        
        public int AddEntity(Chronocourses.Model.Entity Entity) {
            return base.Channel.AddEntity(Entity);
        }
        
        public int DeleteEntity(Chronocourses.Model.Entity Entity) {
            return base.Channel.DeleteEntity(Entity);
        }
        
        public void SaveEntitys() {
            base.Channel.SaveEntitys();
        }
    }
}
