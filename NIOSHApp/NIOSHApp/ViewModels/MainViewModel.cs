using NIOSHApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIOSHApp.ViewModels
{
    class MainViewModel
    {
        NavigationService navigationService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
            LoadMenu();
        }

        #region Properties

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        #endregion


        #region Methods

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>(); //Instanciamos un menu
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "Entrada",
                PageName = "MainPage"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "Calcular",
                PageName = "CalcularPage"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_orders",
                Title = "Adjuntar",
                PageName = "AdjuntarPage"
            });

        }

        #endregion
    }
}
