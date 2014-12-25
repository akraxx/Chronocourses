//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Chronocourses.Model
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Product))]
    public partial class TypeProduct: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Propriétés primitives
    
        [DataMember]
        public int ID
        {
            get { return _iD; }
            set
            {
                if (_iD != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("La propriété 'ID' fait partie de la clé de l'objet et ne peut pas être modifiée. Les modifications des propriétés de clés sont possibles à condition que l'objet ne soit pas suivi ou qu'il soit dans l'état ajouté.");
                    }
                    _iD = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private int _iD;
    
        [DataMember]
        public string Label
        {
            get { return _label; }
            set
            {
                if (_label != value)
                {
                    _label = value;
                    OnPropertyChanged("Label");
                }
            }
        }
        private string _label;

        #endregion
        #region Propriétés de navigation
    
        [DataMember]
        public TrackableCollection<Product> Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new TrackableCollection<Product>();
                    _product.CollectionChanged += FixupProduct;
                }
                return _product;
            }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Impossible de définir FixupChangeTrackingCollection lorsque ChangeTracking est activé");
                    }
                    if (_product != null)
                    {
                        _product.CollectionChanged -= FixupProduct;
                        // Il s'agit de l'extrémité principale dans une association qui effectue des suppressions en cascade.
                        // Supprimez le gestionnaire d'événements des suppressions en cascade pour toutes les entités dans la collection actuelle.
                        foreach (Product item in _product)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _product = value;
                    if (_product != null)
                    {
                        _product.CollectionChanged += FixupProduct;
                        // Il s'agit de l'extrémité principale dans une association qui effectue des suppressions en cascade.
                        // Ajoutez le gestionnaire d'événements des suppressions en cascade pour toutes les entités qui figurent déjà dans la nouvelle collection.
                        foreach (Product item in _product)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("Product");
                }
            }
        }
        private TrackableCollection<Product> _product;

        #endregion
        #region Suivi des modifications
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Product.Clear();
        }

        #endregion
        #region Correction d'association
    
        private void FixupProduct(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Product item in e.NewItems)
                {
                    item.TypeProduct = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Product", item);
                    }
                    // Il s'agit de l'extrémité principale dans une association qui effectue des suppressions en cascade.
                    // Mettez à jour l'écouteur d'événement pour faire référence au nouveau dépendant.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product item in e.OldItems)
                {
                    if (ReferenceEquals(item.TypeProduct, this))
                    {
                        item.TypeProduct = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Product", item);
                    }
                    // Il s'agit de l'extrémité principale dans une association qui effectue des suppressions en cascade.
                    // Supprimez le dépendant précédent de l'écouteur d'événement.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }

        #endregion
    }
}
