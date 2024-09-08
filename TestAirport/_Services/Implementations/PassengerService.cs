using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAirport._Repositories.Interfaces;
using TestAirport._Services.Interfaces;
using TestAirport.Model;

namespace TestAirport._Services.Implementations
{
    internal class PassengerService : ILoadSaveService
    {
        private readonly IDataRepository _dataRepository;

        public PassengerService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public T? Load<T>()
        {
            return _dataRepository.LoadData<T>();
        }

        public void Save<T>(T dataToSave)
        {
           _dataRepository.SaveData(dataToSave);
        }
    }
}
