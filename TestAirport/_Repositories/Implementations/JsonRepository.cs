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
    public class JsonRepository : IDataRepository
    {
        private const string _fileFormat = "json";

        public T? LoadData<T>()
        {
            string filename = $"{typeof(T).Name}.{_fileFormat}";
            if (File.Exists(filename))
            {
                var jsonString = File.ReadAllText(filename);
                return JsonSerializer.Deserialize<T>(jsonString);
            }

            return default;
        }

        public void SaveData<T>(T dataToSave)
        {
            string filename = $"{typeof(T).Name}.{_fileFormat}";

            var jsonString = JsonSerializer.Serialize(dataToSave);
            File.WriteAllText(filename, jsonString);
        }
    }
}
