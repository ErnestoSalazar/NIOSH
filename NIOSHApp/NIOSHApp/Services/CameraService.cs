using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIOSHApp.Services
{
    class CameraService
    {

        DialogService dialogService;
        public CameraService()
        {
            dialogService = new DialogService();
        }

        private async void UploadPictureButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await dialogService.ShowMessage("No se puede cargar foto", "Cargar foto de la galeria no es soportado");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null) return;

            //Image1.Source = ImageSource.FromStream(() => file.GetStream());

        }

        private async void TakePictureButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize(); //Current representa la instancia singleton de esta clase

            //Si la camara no esta disponible o no soporta la toma de fotos
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await dialogService.ShowMessage("No hay camara", "Camara no disponible");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = "Test.jpg"
            });

            if (file == null) return;

            //Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }
    }
}
