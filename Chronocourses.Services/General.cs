using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chronocourses.DataAccess;
using Chronocourses.DataAccess.Managers;

namespace Chronocourses.Services
{
    public class General : IGeneral
    {
        public void SaveData()
        {
            DataContext.Save();
        }
    }
}
