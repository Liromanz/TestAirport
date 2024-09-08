using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAirport._Repositories.Interfaces
{
    internal interface IDataRepository
    {
        void SaveData<T>(T dataToSave);
        T? LoadData<T>();
    }
}
