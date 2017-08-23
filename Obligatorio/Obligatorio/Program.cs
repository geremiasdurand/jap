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
        public static int IDProducto = 0;

        public static void MenuPrincipal()
        {
            try
            {
                int Entrada = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1- Registros\n2- Listados\n3- Salir");
                    int.TryParse(Console.ReadLine(), out Entrada);
                    if (Entrada == 1)
                    {
                        MenuRegistro();
                    }
                    else if (Entrada == 2)
                    {
                        MenuListado();
                    }else if(Entrada == 3)
                    {
                        //para que finalize el programa
                        Entrada = 1;
                    }
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
            try
            {
                string nombreCliente;
                do
                {
                    Console.WriteLine("Ingrese el NOMBRE del Nombre");
                    nombreCliente = Console.ReadLine();
                }
                while (nombreCliente == string.Empty);

                string cirutCliente;
                bool buscar = false;
                do
                {
                    Console.WriteLine("Ingrese la CI o RUT del Cliente");
                    cirutCliente = Console.ReadLine();
                    if (cirutCliente != string.Empty && int.TryParse(cirutCliente, out int preciotemp))
                    {
                        if (BuscarCliente(int.Parse(cirutCliente))==null)
                        {
                            buscar = true;
                        }
                        else
                        {
                            Console.WriteLine("Ya hay un Cliente registrado con esa CI/RUT");
                        }
                    }
                }
                while (!buscar);

                Console.WriteLine("Ingrese el CANTIDAD de la Memoria");
                string cantidadMemoria = Console.ReadLine();

                string domicilioCliente;
                do
                {
                    Console.WriteLine("Ingrese el DOMICILIO del Cliente");
                    domicilioCliente = Console.ReadLine();
                }
                while (domicilioCliente == string.Empty);

                string fechadenacimientoCliente;
                do
                {
                    Console.WriteLine("Ingrese la CI o RUT del Cliente");
                    fechadenacimientoCliente = Console.ReadLine();
                }
                while (fechadenacimientoCliente == string.Empty || !DateTime.TryParse(fechadenacimientoCliente, out DateTime fechatemp));

                Cliente NuevoCliente = new Cliente();
                NuevoCliente.Nombre = nombreCliente;
                NuevoCliente.CIRUT = int.Parse(cirutCliente);
                NuevoCliente.Domicilio = domicilioCliente;
                NuevoCliente.FechaDeNacimiento = DateTime.Parse(fechadenacimientoCliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
        public static void Registrar_Factura()
        {



        }
        public static void Registrar_Producto()
        {
            try
            {
                string nombreProducto;
                do
                {
                    Console.WriteLine("Ingrese el NOMBRE del Producto");
                    nombreProducto = Console.ReadLine();
                }
                while (nombreProducto != string.Empty);

                string marcaProducto;
                do
                {
                    Console.WriteLine("Ingrese la MARCA del Producto");
                    marcaProducto = Console.ReadLine();
                }
                while (marcaProducto != string.Empty);

                string precioProducto;
                int preciotemp;
                do
                {
                    Console.WriteLine("Ingrese el PRECIO del Producto");
                    precioProducto = Console.ReadLine();
                }
                while (precioProducto != string.Empty && !int.TryParse(precioProducto, out preciotemp) && preciotemp > 0);

                string cantidadMemoria;
                do
                {
                    Console.WriteLine("Ingrese el CANTIDAD de la Memoria");
                    cantidadMemoria = Console.ReadLine();
                }
                while (cantidadMemoria != string.Empty);

                Producto NuevoProducto = new Producto();
                NuevoProducto.Nombre = nombreProducto;
                NuevoProducto.Marca = marcaProducto;
                NuevoProducto.PrecioPorUnidad = int.Parse(precioProducto);
                NuevoProducto.Id = IDProducto;
                IDProducto++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("================ PRODUCTO AGREGADO ================");
            Console.ReadLine();
        }

        public static void Listar_Cliente()
        {
            Console.WriteLine("=============== LISTADO DE CLIENTES ===============");
            Console.WriteLine("");
            foreach(Cliente c in ListaClientes)
            {
                Console.WriteLine("CI/RUT: {0} ,Nombre: {1} ,Domicilio: {2} ,FechaDeNacimiento: {3}",c.CIRUT,c.Nombre,c.Domicilio,c.FechaDeNacimiento);
            }
            Console.WriteLine("");
            Console.WriteLine("===================================================");
        }
        public static void Listar_Factura()
        {
            Console.WriteLine("=============== LISTADO DE FACTURAS ===============");
            Console.WriteLine("");
            if (ListaFacturas.Count > 0)
            {
                foreach (Factura f in ListaFacturas)
                {
                    Console.WriteLine("Nombre Comprador: {0} ,CI/RUT: {1} ,Monto A Pagar: {2}", f.Cliente.Nombre, f.Cliente.CIRUT, f.MontoTotal);
                }
            }
            else
            {
                Console.WriteLine("No hay ninguna Factura registrada en el sistema.");
            }
            Console.WriteLine("");
            Console.WriteLine("===================================================");

        }
        public static void Listar_Producto()
        {
            Console.WriteLine("=============== LISTADO DE PRODUCTOS ===============");
            Console.WriteLine("");
            foreach (Producto p in ListaProductos)
            {
                Console.WriteLine("Id: {0} ,Nombre: {1} ,Marca: {2} ,Precio: {3}", p.Id, p.Nombre, p.Marca, p.PrecioPorUnidad);
            }
            Console.WriteLine("");
            Console.WriteLine("===================================================");
        }

        public static Cliente BuscarCliente(int cirut)
        {
            foreach(Cliente c in ListaClientes)
            {
                if (c.CIRUT == cirut)
                {
                    return c;
                }
            }
            return null;
        }
    }

  

}
