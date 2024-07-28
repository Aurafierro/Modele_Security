using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class producto
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private string descripcion { get; set; }
        private int precio { get; set; }
        private int id_categoria { get; set; }



        public producto(int id, string nombre, string descripcion, int precio, int id_categoria)
        {
            id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            precio = precio;
            id_categoria = id_categoria;
        }

        public void RegistrarProcducto()
        {
           // producto nuevo_producto = new producto(id, nombre, descripcion, precio, id_categoria);
            Console.WriteLine($"Producto registro: {nombre}, {descripcion}. Precio: ${precio}, categoria {id_categoria}");

        }
    }



}
   

