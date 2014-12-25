using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Chronocourses.Services
{
    [ServiceContract]
    public interface IGeneral
    {
        [OperationContract]
        void SaveData();
    }
}
