using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            producto producto1 = new producto(1, "Labial", "Labial rojo", 20, 101);
            producto1.RegistrarProcducto();





            producto producto2 = new producto(2, "Champú", "Champú anticaspa", 10, 102);


           
            Categoria categoria1 = new Categoria("101", "Cosméticos", "Cuidado personal", "Deportes", "Artes");
            Categoria categoria2 = new Categoria("102", "Salud", "Limpieza", "Ejercicio", "Manualidades");

           
        }
    }
}
