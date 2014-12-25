using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.ObjectModel;
using Chronocourses.Model;
using System.ServiceModel.Activation;

namespace Chronocourses.Services
{
    [ServiceContract]
    public interface IBrandService
    {
        [OperationContract]
        ObservableCollection<Brand> GetBrands();

        [OperationContract]
        Brand GetBrand(int id);

        [OperationContract]
        int SaveBrand(Brand brand);

        [OperationContract]
        int AddBrand(Brand brand);

        [OperationContract]
        int DeleteBrand(Brand brand);
    }
}
