using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aterrizar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string codigo, origen, destino;
            float precio;
            int i, opcion;
            const int max = 5;

            CViaje[] viajes = new CViaje[max];

            for (i = 0; i < max; i++)
            {
                codigo = leerCodigo();
                origen = leerOrigen();
                destino = leerDestino();

                precio = leerPrecio();

                viajes[i] = new CViaje(codigo, origen, destino);
                viajes[i].precio = precio;
            }            

            Console.WriteLine("Seleccione una opcion: ");
            Console.WriteLine("1---Buscar vuelo por codigo.");
            Console.WriteLine("2---Buscar todos los vuelos segun el origen.");
            Console.WriteLine("3---Buscar todos los vuelos segun el destino.");
            opcion = int.Parse(Console.ReadLine());

            menu(opcion, viajes);

        }   

        static string leerOrigen()
        {
            Console.WriteLine("Ingrese el origen: ");
            return Console.ReadLine();
        }

        static string leerDestino()
        {
            Console.WriteLine("Ingrese el destino: ");
            return Console.ReadLine();
        }

        static string leerCodigo()
        {
            Console.WriteLine("Ingrese el codigo: ");
            return Console.ReadLine();
        }

        static float leerPrecio()
        {
            Console.WriteLine("Ingrese el precio:");
            return float.Parse(Console.ReadLine());
        }
        
        private static void menu(int opcion, CViaje[] viajes)
        {
            string codigo, origen, destino;
            int posicion;

            switch (opcion)
            {
                case 1:

                    Console.WriteLine("Ingrese el codigo: ");
                    Console.WriteLine("Ingrese FIN para finalizar.");
                    codigo = Console.ReadLine();

                    while (codigo != "FIN")
                    {
                        posicion = buscar(viajes, codigo);

                        if (posicion < 0)
                        {
                            Console.WriteLine("No hay ningún vuelo con ese codigo.");
                        }
                        else
                        {
                            Console.WriteLine(viajes[posicion].darDatos());
                            precioFinal(viajes, posicion);                            
                        }
                        Console.WriteLine("Ingrese el codigo: ");
                        codigo = Console.ReadLine();
                    }

                    Console.WriteLine("Presione cualquier tecla para finalizar el programa.");
                    Console.ReadKey();

                    break;

                case 2:

                    Console.WriteLine("Ingrese el origen: ");
                    origen = Console.ReadLine();

                    if (buscarOrigen(viajes, origen) == false)
                    {
                        Console.WriteLine("No se encontraron vuelos con ese origen.");
                    }

                    Console.WriteLine("Presione cualquier tecla para finalizar el programa.");
                    Console.ReadKey();

                    break;

                case 3:

                    Console.WriteLine("Ingrese el destino: ");
                    destino = Console.ReadLine();

                    if (buscarDestino(viajes, destino) == false)
                    {
                        Console.WriteLine("No se encontraron vuelos con ese destino.");
                    }

                    Console.WriteLine("Presione cualquier tecla para finalizar el programa.");
                    Console.ReadKey();

                    break;

                default:

                    Console.WriteLine("Opcion incorrecta, vuelva a elegir una opcion valida.");
                    Console.WriteLine("Seleccione una opcion: ");
                    Console.WriteLine("1---Buscar vuelo por codigo.");
                    Console.WriteLine("2---Buscar todos los vuelos segun el origen.");
                    Console.WriteLine("3---Buscar todos los vuelos segun el destino.");
                    opcion = int.Parse(Console.ReadLine());
                    menu(opcion, viajes);

                    break;
            }
        
        }

        private static int buscar(CViaje[] viajes, string codigo)
        {
            int i = 0;

            while (i < viajes.Length)
            {
                if (viajes[i].getCodigo() == codigo)
                {
                    return i;
                }
                i++;
            }

            return -1;

        }

        private static bool buscarOrigen(CViaje[] viajes, string origen)
        {
            int i = 0;
            bool encontrado = false;

            while (i < viajes.Length)
            {
                if (viajes[i].getOrigen() == origen)
                {
                    encontrado = true;
                    Console.WriteLine(viajes[i].darDatos());
                }
                i++;
            }

            return encontrado;

        }

        private static bool buscarDestino(CViaje[] viajes, string destino)
        {
            int i = 0;
            bool encontrado = false;

            while (i < viajes.Length)
            {
                if (viajes[i].getDestino() == destino)
                {
                    encontrado = true;
                    Console.WriteLine(viajes[i].darDatos());
                }
                i++;
            }

            return encontrado;

        }

        private static void precioFinal(CViaje[] viajes, int posicion)
        {
            int cuotas;
            float precFinal;
                        
            Console.WriteLine("Ingrese la cantidad de cuotas (1, 3, 6, 12): ");
            cuotas = int.Parse(Console.ReadLine());
            precFinal = viajes[posicion].darPrecio(cuotas);
            if(precFinal < 0)
            {
                Console.WriteLine("cantidad incorrecta de cuotas.");
                precioFinal(viajes, posicion);
            }
            else
            {
                Console.WriteLine("Precio final: " + precFinal);
            }
        }
    }
}
