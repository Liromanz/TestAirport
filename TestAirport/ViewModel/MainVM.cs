using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAirport._Services.Implementations;
using TestAirport._Services.Interfaces;
using TestAirport.Model;
using TestAirport.ViewModel.BindingHelper;

namespace TestAirport.ViewModel
{
    internal class MainVM : NotifyHelper
    {
        #region Свойства
        private readonly ILoadSaveService _service;


        private ObservableCollection<PassengerModel> passengers = new ObservableCollection<PassengerModel>();
        public ObservableCollection<PassengerModel> Passengers
        {
            get { return passengers; }
            set
            {
                passengers = value;
                Notify();
            }
        }
        #endregion



        #region Команды
        public RelayCommand LoadFromFileCommand { get; set; }
        public RelayCommand SaveToFileCommand { get; set; }
        #endregion



        public MainVM(ILoadSaveService service)
        {
            _service = service;

            LoadFromFileCommand = new RelayCommand(LoadFromFile);
            SaveToFileCommand = new RelayCommand(SaveToFile);
        }



        #region Методы
        private void LoadFromFile()
        {
            Passengers = _service.Load<ObservableCollection<PassengerModel>>() ?? new ObservableCollection<PassengerModel>();
        }

        private void SaveToFile()
        {
            _service.Save(Passengers);
        }
        #endregion
    }
}
