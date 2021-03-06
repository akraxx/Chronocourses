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
    public partial class Container : Entity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
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
                    }
                    _product = value;
                    if (_product != null)
                    {
                        _product.CollectionChanged += FixupProduct;
                    }
                    OnNavigationPropertyChanged("Product");
                }
            }
        }
        private TrackableCollection<Product> _product;

        #endregion
        #region Suivi des modifications
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
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
                    item.Container = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Product", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product item in e.OldItems)
                {
                    if (ReferenceEquals(item.Container, this))
                    {
                        item.Container = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Product", item);
                    }
                }
            }
        }

        #endregion
    }
}
