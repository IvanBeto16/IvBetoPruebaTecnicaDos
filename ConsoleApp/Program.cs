using PruebaTec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prueba prueba = new Prueba();
            Prueba pruebaDos = new Prueba(10, "Años");

            Prueba.Inicio(prueba,20);
            Prueba.Inicio(pruebaDos, 13);

            Console.ReadKey();
        }
    }
}
