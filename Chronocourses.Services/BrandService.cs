using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronocourses.DataAccess;
using Chronocourses.DataAccess.Managers;
using System.Collections.ObjectModel;
using Chronocourses.Model;
using System.ServiceModel.Activation;

namespace Chronocourses.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BrandService : IBrandService
    {
        public ObservableCollection<Brand> GetBrands()
        {
            return BrandManager.Instance.GetListBrands();
        }


        public Brand GetBrand(int id)
        {
            return BrandManager.Instance.GetBrand(id);
        }

        public int SaveBrand(Brand brand)
        {
            return BrandManager.Instance.SaveBrand(brand);
        }

        public int AddBrand(Brand brand)
        {
            return BrandManager.Instance.AddBrand(brand);
        }

        public int DeleteBrand(Brand brand)
        {
            return BrandManager.Instance.DeleteBrand(brand);
        }
    }
}
