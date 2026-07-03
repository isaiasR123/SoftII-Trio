using BiblioBack.Dominio;

namespace proyecto;

class Program
{
    static List<Activo> activos = new();
    static List<Laboratorio> laboratorios = new();

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
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

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
        string ubicacion = Console.ReadLine();

        Laboratorio laboratorio = new Laboratorio(nombre, ubicacion);

        laboratorios.Add(laboratorio);

        Console.WriteLine("Laboratorio registrado correctamente.");
        Console.ReadKey();
    }

    static void RegistrarComputadora()
    {
        Console.Write("Marca: ");
        string marca = Console.ReadLine();

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        Console.Write("Código: ");
        string codigo = Console.ReadLine();

        Console.Write("RAM (GB): ");
        int.TryParse(Console.ReadLine(), out int ram);

        Computadora pc = new Computadora(marca, modelo, codigo, ram);

        activos.Add(pc);

        Console.WriteLine("Computadora registrada correctamente.");
        Console.ReadKey();
    }

    static void MostrarActivos()
    {
        Console.WriteLine("\n===== ACTIVOS REGISTRADOS =====");

        if (activos.Count == 0)
        {
            Console.WriteLine("No hay activos registrados.");
        }
        else
        {
            foreach (Activo activo in activos)
            {
                activo.MostrarInformacion();
                Console.WriteLine("----------------------------");
            }
        }

        Console.ReadKey();
    }
}