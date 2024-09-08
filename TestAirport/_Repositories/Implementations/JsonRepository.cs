using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestAirport._Repositories.Interfaces;

namespace TestAirport._Repositories.Implementations
{
    internal class JsonRepository : IDataRepository
    {
        private readonly string _fileName;

        public JsonRepository(string fileName)
        {
            _fileName = fileName;
        }

        public T? LoadData<T>()
        {
            if (File.Exists(_fileName))
            {
                var jsonString = File.ReadAllText(_fileName);
                return JsonSerializer.Deserialize<T>(jsonString);
            }

            return default;
        }

        public void SaveData<T>(T dataToSave)
        {
            var jsonString = JsonSerializer.Serialize(dataToSave);
            File.WriteAllText(_fileName, jsonString);
        }
    }
}
