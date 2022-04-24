using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterrizar
{
    internal class CViaje
    {
        string codigo;
        string origen;
        string destino;

        public CViaje(string codigo, string origen, string destino)
        {
            this.codigo = codigo;
            this.origen = origen;
            this.destino = destino;
        }

        public string getCodigo()
        {
            return this.codigo;
        }

        public string getOrigen()
        {
            return this.origen;
        }

        public string getDestino()
        {
            return this.destino;
        }

        public float precio { get ; set ; }

        public float darPrecio(int cuotas)
        {
            float precioFinal;

            switch (cuotas)
            {
                case 1:

                    precioFinal = precio + precio * 0;

                    break;

                case 3:
                     
                    precioFinal = precio + precio * 0.1f;

                    break;
                case 6:
                    
                    precioFinal = precio + precio * 0.2f;

                    break;
                case 12:

                    precioFinal = precio + precio * 0.4f;

                    break;

                default:

                    precioFinal = -1;

                    break;

            }

            return precioFinal;
        }

        public string darDatos()
        {
            return "Codigo: " + this.codigo + " origen: " + this.origen + " destino: " + this.destino + " precio: " + this.precio.ToString();
        }


    }
}
