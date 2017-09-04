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
            ListaClientes.Add(new Cliente() { CIRUT = 123, Domicilio = "Calle", FechaDeNacimiento = DateTime.Now, Nombre = "Nombre" });
            ListaProductos.Add(new Producto() { Id = 1, Nombre = "Pan", Marca = "Marca", PrecioPorUnidad = 10 });

            MenuPrincipal();
        }

        public static List<Producto> ListaProductos = new List<Producto>();
        public static List<Factura> ListaFacturas = new List<Factura>();
        public static List<Cliente> ListaClientes = new List<Cliente>();
        public static int IDProducto = 2;

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
                    }
                    else if(Entrada == 3)
                    {
                        Environment.Exit(1);
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
                    Console.WriteLine("1- Registrar Cliente\n2- Registrar Factura\n3- Registrar Producto\n4- Menu Principal");
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
                Console.ReadLine();
                MenuPrincipal();
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
                    Console.WriteLine("1- Listar Cliente\n2- Listar Factura\n3- Listar Producto\n4- Menu Principal");
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
                MenuPrincipal();
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
                Console.Clear();
                string nombreCliente;
                do
                {
                    Console.WriteLine("Ingrese el NOMBRE del Cliente");
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
                    else
                    {
                        Console.WriteLine("Debe ingresar solo numeros");
                    }
                }
                while (!buscar);

                string domicilioCliente;
                do
                {
                    Console.WriteLine("Ingrese el DOMICILIO del Cliente");
                    domicilioCliente = Console.ReadLine();
                }
                while (domicilioCliente == string.Empty);

                string fechadenacimientoCliente;
                DateTime fecha = DateTime.Now;
                Boolean SalirFecha = true;
                do
                {
                    Console.WriteLine("Ingrese la FECHA DE NACIMIENTO del Cliente. Ej: DD/MM/YYYY");
                    fechadenacimientoCliente = Console.ReadLine();
                    if (!String.IsNullOrEmpty(fechadenacimientoCliente) && DateTime.TryParse(fechadenacimientoCliente, out fecha))
                    {
                        SalirFecha = true;
                        DateTime hoy = DateTime.Now;
                        TimeSpan resultado = fecha - hoy;

                        //-365 porque el total en dias esta negativo, para poder usar numeros positivos
                        if ((resultado.TotalDays / -365) < 18.00)
                        {
                            SalirFecha = false;
                            Console.WriteLine("El cliente debe ser mayor de edad");
                        }
                    }
                    
                }
                while (!SalirFecha);

                Cliente NuevoCliente = new Cliente();
                NuevoCliente.Nombre = nombreCliente;
                NuevoCliente.CIRUT = int.Parse(cirutCliente);
                NuevoCliente.Domicilio = domicilioCliente;
                NuevoCliente.FechaDeNacimiento = fecha;
                ListaClientes.Add(NuevoCliente);
                Console.WriteLine("================ CLIENTE AGREGADO ================");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
        public static void Registrar_Factura()
        {
            try
            {
                Console.Clear();
                DateTime fechaFactura = DateTime.Now;

                Cliente cliente = new Cliente();
                string clienteFactura;
                bool buscar = false;
                do
                {
                    Console.WriteLine("Ingrese la CI o RUT del Cliente \nEscriba 'Listar' para mostrar los clientes");
                    clienteFactura = Console.ReadLine();
                    if (clienteFactura != string.Empty && int.TryParse(clienteFactura, out int clientetemp))
                    {
                        cliente = BuscarCliente(int.Parse(clienteFactura));
                        if (cliente != null)
                        {
                            buscar = true;
                        }
                        else
                        {
                            Console.WriteLine("No existe un cliente con esa CI/RUT");
                        }
                    }
                    else if (clienteFactura == "Listar")
                    {
                        Listar_Cliente();
                    }
                }
                while (!buscar);

                List<Producto> ProductosEnFactura = new List<Producto>();
                string idproductoFactura;
                bool salir = false;
                do
                {
                    Console.WriteLine("Ingrese el ID de los productos \nEscriba 'Listar' para mostrar los productos \nEscriba '0' para finalizar");
                    idproductoFactura = IsEmpty(Console.ReadLine());
                    if (idproductoFactura == "Listar")
                    {
                        Listar_Producto();
                    }
                    else if (EsNumero(idproductoFactura) < IDProducto && int.Parse(idproductoFactura) != 0)
                    {
                        string cantidad;
                        Console.WriteLine("Ingrese cuantas veces quiere agregar este producto");
                        cantidad = IsEmpty(Console.ReadLine());
                        EsNumero(cantidad);
                        Producto ProductoAdd = BuscarIdProducto(idproductoFactura);
                        for (int i = 0; i < int.Parse(cantidad); i++)
                        {
                            ProductosEnFactura.Add(ProductoAdd);
                        }
                    }
                    else if (EsNumero(idproductoFactura) == 0)
                    {
                        string pregunta = "";
                        do
                        {
                            Console.WriteLine("Quiere terminar la operacion?");
                            Console.WriteLine("1 = SI - 2 = NO");
                            pregunta = Console.ReadLine();
                        }
                        while (int.Parse(pregunta) != 1 && int.Parse(pregunta) != 2);
                        if (int.Parse(pregunta) == 1)
                        {
                            salir = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un dato valido");
                    }
                }
                while (!salir);

                int PrecioTotal = 0;
                foreach (var P in ProductosEnFactura)
                {
                    PrecioTotal += P.PrecioPorUnidad;
                }


                Factura NuevaFactura = new Factura();
                NuevaFactura.Cliente = cliente;
                NuevaFactura.Fecha = fechaFactura;
                NuevaFactura.MontoTotal = PrecioTotal;
                NuevaFactura.ListaProductos = ProductosEnFactura;
                ListaFacturas.Add(NuevaFactura);
                }
                
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("================ FACTURA AGREGADA ================");
            Console.ReadLine();
            MenuPrincipal();
        }
        public static void Registrar_Producto()
        {
            try
            {
                Console.Clear();
                string nombreProducto;
                do
                {
                    Console.WriteLine("Ingrese el NOMBRE del Producto");
                    nombreProducto = Console.ReadLine();
                }
                while (nombreProducto == string.Empty);

                string marcaProducto;
                do
                {
                    Console.WriteLine("Ingrese la MARCA del Producto");
                    marcaProducto = Console.ReadLine();
                }
                while (marcaProducto == string.Empty);

                string precioProducto;
                int preciotemp = 0;
                do
                {
                    Console.WriteLine("Ingrese el PRECIO del Producto");
                    precioProducto = IsEmpty(Console.ReadLine());
                }
                while (!int.TryParse(precioProducto, out preciotemp) || preciotemp == 0);

                Producto NuevoProducto = new Producto();
                NuevoProducto.Nombre = nombreProducto;
                NuevoProducto.Marca = marcaProducto;
                NuevoProducto.PrecioPorUnidad = preciotemp;
                NuevoProducto.Id = IDProducto;
                ListaProductos.Add(NuevoProducto);
                IDProducto++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("================ PRODUCTO AGREGADO ================");
            Console.ReadLine();
            MenuPrincipal();
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
            Console.ReadLine();
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
            Console.ReadLine();
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
            Console.ReadLine();
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

        public static Producto BuscarIdProducto(string id)
        {
            foreach (var i in ListaProductos)
            {
                if (i.Id == int.Parse(id))
                {
                    return i;
                }
            }
            return null;
        }

        public static string IsEmpty(string texto)
        {
            while (texto == "")
            {
                Console.WriteLine("Debe ingresar un dato");
                texto = Console.ReadLine();
            }
            return texto;
        }

        public static int EsNumero(string texto)
        {
            int numero;
            while (!int.TryParse(texto, out numero))
            {
                Console.WriteLine("Debe ingresar un numero");
                texto = Console.ReadLine();
            }
            return numero;
        }
    }
}
