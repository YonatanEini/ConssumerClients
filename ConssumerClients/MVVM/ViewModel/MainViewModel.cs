using ConssumerClients.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssumerClients.MVVM.ViewModel
{
    /// <summary>
    /// Class For The Window View
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ClientsGuiViewCommand { get; set; }

        public HomeViewModel HomwVm { get; set; }
        public ClientsGuiData GuiDataVm { get; set; }
        public static object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomwVm = new HomeViewModel();
            GuiDataVm = new ClientsGuiData();
            CurrentView = HomwVm;
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomwVm;
            });

            ClientsGuiViewCommand = new RelayCommand(o =>
            {
                CurrentView = GuiDataVm;
            });
        }
    }
}
