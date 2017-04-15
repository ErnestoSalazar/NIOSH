using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NIOSHApp.ViewModels
{
    class NioshViewModel
    {
        public double horizontalOrigen { get; set; }
        public double horizontalDestino { get; set; }
        public double verticalOrigen { get; set; }
        public double verticalDestino { get; set; }
        public double distancia { get; set; }
        public double rotacionOrigen { get; set; }
        public double rotacionDestino { get; set; }
        public double frecuencia { get; set; }
        public double duracion { get; set; }
        public string acoplamiento { get; set; }
        public double pesoObjeto { get; set; }

        public ICommand SaveCommand
        {
            get { return new RelayCommand<string>(Save); }
        }

        private void Save(string loquesea)
        {
            horizontalOrigen = this.horizontalOrigen;
            horizontalDestino = this.horizontalDestino;
            verticalOrigen = this.verticalOrigen;
            verticalDestino = this.verticalDestino;
            distancia = this.distancia;
            rotacionOrigen = this.rotacionOrigen;
            rotacionDestino = this.rotacionDestino;
            frecuencia = this.frecuencia;
            duracion = this.duracion;
            acoplamiento = this.acoplamiento;
            pesoObjeto = this.pesoObjeto;

            var hmOrigen = 10 / horizontalOrigen; //Multiplicador horizontal de origen
            var hmDestino = 10 / horizontalDestino; //Multiplicador horizontal de destino

            var vmOrigen = 1 - (.0075 * Math.Abs(verticalOrigen - 30)); //Multiplicador vertical de origen
            var vmDestino = 1 - (.0075 * Math.Abs(verticalDestino - 30)); //Multiplicador vertical de destino

            distancia = verticalDestino - verticalOrigen; //Distancia obtenida de la resta del valor de verticalDestino menos el valor de verticalDestino
            var dm = .82 + (1.8 / distancia); //Multiplicador de distancia

            var amOrigen = 1 - (.0032 * rotacionOrigen); //Multiplicador de asimetría de origen
            var amDestino = 1 - (.0032 * rotacionDestino); //Multiplicador de asimetría de destino

            var fm = .60; //Valor jarcodiado la dvd, la netflix

            var cm = 0.0;

            if (acoplamiento == "bueno")
            {
                cm = 1.0;
            }
            else if (acoplamiento == "regular")
            {
                if(verticalDestino <= 30)
                {
                    cm = 0.95;
                }
                else
                {
                    cm = 1.0;
                }
            }
            else
            {
                cm = 0.90;
            }

            var rwlOrigen = 51 * hmOrigen * vmOrigen * dm * amOrigen * fm * cm; //Recommended Weight Limit de origen
            var rwlDestino = 51 * hmDestino * hmDestino * dm * amDestino * fm * cm; //Recommended Weight Limit de destino

            var liOrigen = pesoObjeto / rwlOrigen; //Lifting Index de origen
            var liDestino = pesoObjeto / rwlDestino; //Lifting Index de destino
        }

    }
}
