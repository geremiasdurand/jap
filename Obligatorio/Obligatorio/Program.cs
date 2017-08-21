using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        public static List<Producto> ListaProductos = new List<Producto>();
        public static List<Factura> ListaFacturas = new List<Factura>();
        public static List<Cliente> ListaClientes = new List<Cliente>();

        public static void MenuPrincipal()
        {
            try
            {
                int Entrada = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1- Registros\n2- Listados");
                    int.TryParse(Console.ReadLine(), out Entrada);
                    if (Entrada == 1)
                    {
                        MenuRegistro();
                    }
                    else if (Entrada == 2)
                    { MenuListado(); }
                }
                while (Entrada != 1 && Entrada != 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuRegistro()
        {
            try
            {
                int Entrada = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1- Registrar Cliente\n2- Registrar Factura\n3- Registrar Producto\n4-Menu Principal");
                    int.TryParse(Console.ReadLine(), out Entrada);
                    switch (Entrada)
                    {
                        case 1:
                            Registrar_Cliente();
                            break;
                        case 2:
                            Registrar_Factura();
                            break;
                        case 3:
                            Registrar_Producto();
                            break;
                        case 4:
                            MenuPrincipal();
                            break;
                    }

                }
                while (Entrada != 1 && Entrada != 2 && Entrada != 3 && Entrada != 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuListado()
        {
            try
            {
                int Entrada = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1- Listar Cliente\n2- Listar Factura\n3- Listar Producto\n4-Menu Principal");
                    int.TryParse(Console.ReadLine(), out Entrada);
                    switch (Entrada)
                    {
                        case 1:
                            Listar_Cliente();
                            break;
                        case 2:
                            Listar_Factura();
                            break;
                        case 3:
                            Listar_Producto();
                            break;
                        case 4:
                            MenuPrincipal();
                            break;
                    }

                }
                while (Entrada != 1 && Entrada != 2 && Entrada != 3 && Entrada != 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Registrar_Cliente()
        {



        }
        public static void Registrar_Factura()
        {



        }
        public static void Registrar_Producto()
        {



        }

        public static void Listar_Cliente()
        {
            Console.WriteLine("=============== LISTADO DE CLIENTES ===============");
            Console.WriteLine("");
            foreach(Cliente c in ListaClientes)
            {
                Console.WriteLine("CI/ROT: {0} ,Nombre: {1} ,Domicilio: {2} ,FechaDeNacimiento: {3}",c.CIRUT,c.Nombre,c.Domicilio,c.FechaDeNacimiento);
            }
            Console.WriteLine("");
            Console.WriteLine("===================================================");
        }
        public static void Listar_Factura()
        {
            Console.WriteLine("=============== LISTADO DE FACTURAS ===============");
            Console.WriteLine("");
            foreach (Factura c in ListaFacturas)
            {
                Console.WriteLine("CI/ROT: {0} ,Nombre: {1} ,Domicilio: {2} ,FechaDeNacimiento: {}");
            }
            Console.WriteLine("");
            Console.WriteLine("===================================================");

        }
        public static void Listar_Producto()
        {



        }

        //nuestra hermana
    }

}
