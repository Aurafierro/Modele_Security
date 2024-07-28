using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Categoria
    {
        private string id_categoria { get; set; }
        private string maquillaje { get; set; }
        private string aseo { get; set; }

        private string deporte { get; set; }
        private string arte { get; set; }


        public Categoria(string id_categoria, string maquillaje, string aseo, string deporte, string arte)
        {
            //El uso de this es opcional
            //utiliza para evitar ambigüedades entre los nombres .
            this.id_categoria = id_categoria;
            this.maquillaje = maquillaje;
            this.aseo = aseo;
            this.deporte = deporte;
            this.arte = arte;
        }
        // metodo
        public void RegistrarCategoria(string id_categoria, string maquilllaje, string aseo, string deporte, string arte)
        {
            Categoria nueva_categoria = new Categoria(id_categoria, maquilllaje, aseo, deporte, arte);
            Console.WriteLine($"Categorias registradas: {maquilllaje}, {aseo},  {deporte},{arte}. ");

        }
    }
    }

