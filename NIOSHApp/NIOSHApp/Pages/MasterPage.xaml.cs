using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NIOSHApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        //En el momento que la pagina aparesca
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Master = this;
            //llevamos a nuestro contexto general a la clase App a una propiedad estatica y publica
            App.Navigator = this.Navigator; //Derecha: Referencia al navigations page ubicado en nuestra masterpage; Izquierda: Referencia a una variable en la clase App.cs
        }
    }
}
