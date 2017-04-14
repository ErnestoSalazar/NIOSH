using GalaSoft.MvvmLight.Command;
using NIOSHApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NIOSHApp.ViewModels
{
    class MainViewModel
    {
        NavigationService navigationService;
        DialogService dialogService;
        CameraService cameraService;
        public MainViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            cameraService = new CameraService();
            LoadMenu();            
        }

        #region Properties

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        #endregion

        #region Commands
        
        public ICommand PhotoOptionsCommand
        {
            get { return new RelayCommand<string>(Photos); }
        }

        private async void Photos(string photo)
        {
            try
            {
                Debug.WriteLine(photo);
                var action = await App.Navigator.DisplayActionSheet("Elige el metodo", null, null, "Tomar Foto", "Cargar de la galeria");

                switch (action)
                {
                    case "Tomar Foto":
                        cameraService.TakePictureButton_Clicked();
                        break;

                    case "Cargar de la galeria":
                        cameraService.UploadPictureButton_Clicked();
                        break;
                    default:
                        break;
                }

            }
            catch
            {
                await dialogService.ShowMessage("Ha ocurrido un error inesperado", "error");
            }
        }


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
