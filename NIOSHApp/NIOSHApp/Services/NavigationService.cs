using System;
using NIOSHApp.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NIOSHApp.Services
{
    class NavigationService
    {
        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false; // Cerramos el menu lateral cada que eligamos una opcion del menu

            switch (pageName)
            {
                case "MainPage":
                    await App.Navigator.PopToRootAsync(); // Nos permite regresar al menu principal sin que se creé una nueva
                    break;
                case "CalcularPage":
                    await Navigate(new CalcularPage());
                    break;
                case "AdjuntarPage":
                    await Navigate(new AdjuntarPage());
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            await App.Navigator.PushAsync(page);
        }

        internal void SetMainPage(Page page)
        {
            App.Current.MainPage = page;
        }

    }
}
