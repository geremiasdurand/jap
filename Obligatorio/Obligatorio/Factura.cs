using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    class Factura
    {
        public DateTime Fecha;
        public Cliente Cliente;
        public int MontoTotal;
        public List<Producto> ListaProductos; 
        public Factura()
        {
            Cliente = new Cliente();
            ListaProductos = new List<Producto>();
        }
    }
}
