using BiblioBack.Data;
using BiblioBack.Dominio;

namespace proyecto;
class Program
{
    static LaboratorioRepositorio laboratorioRepositorio = new();
    static ComputadoraRepositorio computadoraRepositorio = new();

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("===== SISTEMA DE INVENTARIO =====");
            Console.WriteLine("1. Registrar laboratorio");
            Console.WriteLine("2. Registrar computadora");
            Console.WriteLine("3. Mostrar activos");
            Console.WriteLine("4. Actualizar computadora");
            Console.WriteLine("5. Eliminar computadora");
            Console.WriteLine("6. Actualizar laboratorio");
            Console.WriteLine("7. Eliminar laboratorio");
            Console.WriteLine("8. Salir");

            string? opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        RegistrarLaboratorio();
                        break;

                    case "2":
                        RegistrarComputadora();
                        break;

                    case "3":
                        MostrarActivos();
                        break;

                    case "4":
                        ActualizarComputadora();
                        break;

                    case "5":
                        EliminarComputadora();
                        break;

                    case "6":
                        ActualizarLaboratorio();
                        break;

                    case "7":
                        EliminarLaboratorio();
                        break;

                    case "8":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
        }
    }

    static void RegistrarLaboratorio()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Ubicación: ");
        string ubicacion = Console.ReadLine() ?? "";

        Laboratorio laboratorio = new Laboratorio(nombre, ubicacion);

        laboratorioRepositorio.Agregar(laboratorio);

        Console.WriteLine("Laboratorio registrado correctamente.");
        Console.ReadKey();
    }

    static void RegistrarComputadora()
    {
        Console.Write("Marca: ");
        string marca = Console.ReadLine() ?? "";

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine() ?? "";

        Console.Write("Código: ");
        string codigo = Console.ReadLine() ?? "";

        Console.Write("RAM (GB): ");
        int.TryParse(Console.ReadLine(), out int ram);

        Computadora pc = new Computadora(marca, modelo, codigo, ram);

        computadoraRepositorio.Agregar(pc);

        Console.WriteLine("Computadora registrada correctamente.");
        Console.ReadKey();
    }

    static void MostrarActivos()
    {
        Console.WriteLine("\n===== LABORATORIOS =====");

        var laboratorios = laboratorioRepositorio.ObtenerTodos();

        if (laboratorios.Count == 0)
        {
            Console.WriteLine("No hay laboratorios registrados.");
        }
        else
        {
            foreach (Laboratorio laboratorio in laboratorios)
            {
                Console.WriteLine($"Nombre: {laboratorio.Nombre}");
                Console.WriteLine($"Ubicación: {laboratorio.Ubicacion}");
                Console.WriteLine("----------------------------");
            }
        }

        Console.WriteLine("\n===== COMPUTADORAS =====");

        var computadoras = computadoraRepositorio.ObtenerTodas();

        if (computadoras.Count == 0)
        {
            Console.WriteLine("No hay computadoras registradas.");
        }
        else
        {
            foreach (Computadora computadora in computadoras)
            {
                computadora.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }
        }

        Console.ReadKey();
    }

    static void ActualizarComputadora()
    {
        Console.WriteLine("Función en desarrollo.");
        Console.ReadKey();
    }

    static void EliminarComputadora()
    {
        Console.WriteLine("Función en desarrollo.");
        Console.ReadKey();
    }

    static void ActualizarLaboratorio()
    {
        Console.WriteLine("Función en desarrollo.");
        Console.ReadKey();
    }

    static void EliminarLaboratorio()
    {
        Console.WriteLine("Función en desarrollo.");
        Console.ReadKey();
    }
}