﻿using System.Collections.Generic;
using Gardenr.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Gardenr.Repositories
{
    interface ITaalRepository
    {
        Task<Taal> GetTaalById(string id);
        Task<ObservableCollection<Taal>> GetTalen();
        void AddTaal();
    }
}