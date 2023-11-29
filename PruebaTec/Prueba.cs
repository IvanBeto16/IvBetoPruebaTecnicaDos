using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTec
{
    public class Prueba
    {
        public string Nombre { get; } = "Leonardo";
        public int Valor { get; set; }
        public string Clave { get; set; }
        public string[] Arreglo { get; set; }

        //Sobrecarga de constructores
        public Prueba()
        {
            Valor = 16;
            Clave = "Edad";
            Arreglo = new string[] { "Nombre", "Apellido", "FechaNacimiento" };
        }

        public Prueba(int valor)
        {
            Valor = valor;
            Clave = "Edad";
            Arreglo = new string[] { "Nombre", "Apellido", "FechaNacimiento" };
        }

        public Prueba(int valor, string clave)
        {
            Valor = valor;
            Clave = clave;
            Arreglo = new string[] { "Nombre", "Apellido", "FechaNacimiento" };
        }

        protected static void funcion()
        {
            Prueba prueba = new Prueba();
            Console.WriteLine("Valores del objeto de Prueba: ");
            Console.WriteLine(" " + prueba.Nombre);
            Console.WriteLine(" " + prueba.Valor);
            Console.WriteLine(" " + prueba.Clave);
            Console.WriteLine("Valores del arreglo de Strings: ");
            foreach(string item in prueba.Arreglo)
            {
                Console.WriteLine("->" + item);
            }
            Console.WriteLine("*************************");
        }

        public void SumaPrueba(int valor)
        {
            int resultado = 10 + valor;
            Prueba prueba = new Prueba();
            prueba.Valor = resultado;
            Console.WriteLine("Se cambió el valor del objeto a: " + prueba.Valor);
        }


        public static void Inicio(Prueba prueba, int valor)
        {
            prueba.SumaPrueba(valor);
            for(int i=0; i<5; i++)
            {
                funcion();
            } 
        }
    }
}
