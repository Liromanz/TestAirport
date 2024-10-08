﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAirport._Services.Interfaces
{
    public interface ILoadSaveService
    {
        void Save<T>(T dataToSave);
        T? Load<T>();
    }
}
