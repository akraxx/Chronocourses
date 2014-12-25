﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chronocourses.Manager.ShopService {
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
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, Chronocourses.Manager.ShopService.ObjectList> {
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
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, Chronocourses.Manager.ShopService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/Chronocourses.Model", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    [System.SerializableAttribute()]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ShopService.IShopService")]
    public interface IShopService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/GetShops", ReplyAction="http://tempuri.org/IShopService/GetShopsResponse")]
        Chronocourses.Model.Shop[] GetShops();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/GetShop", ReplyAction="http://tempuri.org/IShopService/GetShopResponse")]
        Chronocourses.Model.Shop GetShop(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/GetShortestPath", ReplyAction="http://tempuri.org/IShopService/GetShortestPathResponse")]
        int[][][] GetShortestPath(Chronocourses.Model.Shop shop, int[] startPos, Chronocourses.Model.Product[] lP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/SaveShop", ReplyAction="http://tempuri.org/IShopService/SaveShopResponse")]
        int SaveShop(Chronocourses.Model.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/moveEntityFromShop", ReplyAction="http://tempuri.org/IShopService/moveEntityFromShopResponse")]
        int moveEntityFromShop(Chronocourses.Model.Entity ent, int[] newPos, Chronocourses.Model.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/AddShop", ReplyAction="http://tempuri.org/IShopService/AddShopResponse")]
        int AddShop(Chronocourses.Model.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/DeleteShop", ReplyAction="http://tempuri.org/IShopService/DeleteShopResponse")]
        int DeleteShop(Chronocourses.Model.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/GetEntityByPosition", ReplyAction="http://tempuri.org/IShopService/GetEntityByPositionResponse")]
        Chronocourses.Model.Entity GetEntityByPosition(int x, int y, Chronocourses.Model.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopService/GetProductsByProductType", ReplyAction="http://tempuri.org/IShopService/GetProductsByProductTypeResponse")]
        Chronocourses.Model.Product[] GetProductsByProductType(Chronocourses.Model.TypeProduct typeProduct, Chronocourses.Model.Shop shop);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IShopServiceChannel : Chronocourses.Manager.ShopService.IShopService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ShopServiceClient : System.ServiceModel.ClientBase<Chronocourses.Manager.ShopService.IShopService>, Chronocourses.Manager.ShopService.IShopService {
        
        public ShopServiceClient() {
        }
        
        public ShopServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ShopServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShopServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShopServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Chronocourses.Model.Shop[] GetShops() {
            return base.Channel.GetShops();
        }
        
        public Chronocourses.Model.Shop GetShop(int id) {
            return base.Channel.GetShop(id);
        }
        
        public int[][][] GetShortestPath(Chronocourses.Model.Shop shop, int[] startPos, Chronocourses.Model.Product[] lP) {
            return base.Channel.GetShortestPath(shop, startPos, lP);
        }
        
        public int SaveShop(Chronocourses.Model.Shop shop) {
            return base.Channel.SaveShop(shop);
        }
        
        public int moveEntityFromShop(Chronocourses.Model.Entity ent, int[] newPos, Chronocourses.Model.Shop shop) {
            return base.Channel.moveEntityFromShop(ent, newPos, shop);
        }
        
        public int AddShop(Chronocourses.Model.Shop shop) {
            return base.Channel.AddShop(shop);
        }
        
        public int DeleteShop(Chronocourses.Model.Shop shop) {
            return base.Channel.DeleteShop(shop);
        }
        
        public Chronocourses.Model.Entity GetEntityByPosition(int x, int y, Chronocourses.Model.Shop shop) {
            return base.Channel.GetEntityByPosition(x, y, shop);
        }
        
        public Chronocourses.Model.Product[] GetProductsByProductType(Chronocourses.Model.TypeProduct typeProduct, Chronocourses.Model.Shop shop) {
            return base.Channel.GetProductsByProductType(typeProduct, shop);
        }
    }
}
