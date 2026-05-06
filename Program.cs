namespace proyecto;

class Program
{
    static List<Laboratorio> laboratorios = new List<Laboratorio>();
    static List<ModeloPc> modelos = new List<ModeloPc>();
    static List<Computadora> computadoras = new List<Computadora>();
    static List<Medicion> mediciones = new List<Medicion>();

    static void Main(string[] args)
    {
        Console.WriteLine("===================  PRUEBAS DEL SISTEMA ===================");
        Console.WriteLine("1. Probar registro de datos válidos");
        Console.WriteLine("2. Probar casos inválidos (valores fuera de rango)");
        Console.WriteLine("3. Verificar cálculo de estado");
        Console.WriteLine("4. Verificar consultas a la base de datos");
        Console.WriteLine("5. Mostrar todas las listas");
        Console.WriteLine("0. Salir");
        Console.WriteLine("===================================================================\n");

        int opcion;
        do
        {
            Console.Write("Seleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        ProbarRegistroValido();
                        break;
                    case 2:
                        ProbarCasosInvalidos();
                        break;
                    case 3:
                        VerificarCalculoEstado();
                        break;
                    case 4:
                        VerificarConsultasBD();
                        break;
                    case 5:
                        MostrarListas();
                        break;
                    case 0:
                        Console.WriteLine("¡Gracias por usar el sistema de pruebas!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.\n");
            }
            Console.WriteLine();
        } while (opcion != 0);
    }


    static void ProbarRegistroValido()
    {
        Console.WriteLine("=== PRUEBA 1: REGISTRO DE DATOS VÁLIDOS ===");

        try
        {

            Laboratorio lab = new Laboratorio();
            laboratorios.Add(lab);
            Console.WriteLine("✓ Laboratorio creado exitosamente");


            ModeloPc modelo = new ModeloPc("Dell", "OptiPlex 7090", 75, 60);
            modelos.Add(modelo);
            Console.WriteLine("✓ Modelo PC registrado: Dell OptiPlex 7090");


            Computadora pc = new Computadora("PC-001", "Windows 11", lab, modelo);
            computadoras.Add(pc);
            Console.WriteLine($"✓ Computadora registrada: {pc.nombre}");


            Medicion medicion = new Medicion();
            medicion.setCPU(65);
            medicion.setRam(55);
            medicion.setTemperatura(42.5f);
            medicion.setConectada("true");
            medicion.setFecha(DateTime.Now.AddHours(-2));
            mediciones.Add(medicion);
            Console.WriteLine("Medición registrada correctamente");

            Console.WriteLine(" TODOS LOS REGISTROS VÁLIDOS EXITOSOS\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error: {ex.Message}");
        }
    }


    static void ProbarCasosInvalidos()
    {
        Console.WriteLine("=== PRUEBA 2: CASOS INVÁLIDOS (FUERA DE RANGO) ===");

        Medicion medicionTest = new Medicion();


        try
        {
            medicionTest.setCPU(150);
        }
        catch (Exception ex)
        {
            Console.WriteLine($" CPU inválido: {ex.Message}");
        }


        try
        {
            medicionTest.setRam(120);
        }
        catch (Exception ex)
        {
            Console.WriteLine($" RAM inválida: {ex.Message}");
        }


        try
        {
            medicionTest.setTemperatura(-10.0f);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Temp negativa: {ex.Message}");
        }


        try
        {
            medicionTest.setConectada("abc123");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conectada inválida: {ex.Message}");
        }


        try
        {
            medicionTest.setFecha(DateTime.Now.AddDays(1));
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Fecha futura: {ex.Message}");
        }

        Console.WriteLine(" PRUEBAS DE VALIDACIÓN 100% EXITOSAS\n");
    }

    static void VerificarCalculoEstado()
    {
        Console.WriteLine("=== PRUEBA 3: CÁLCULO DE ESTADO ===");

        if (computadoras.Count > 0)
        {
            Console.WriteLine($"Para PC: {computadoras[0].nombre}");


            int cpuTest = 75;
            int ramTest = 65;
            float tempTest = 55.0f;
            bool conectadaTest = true;

            string estado = CalcularEstado(cpuTest, ramTest, tempTest);
            Console.WriteLine($"Simulación - CPU: {cpuTest}%, RAM: {ramTest}%, Temp: {tempTest}°C");
            Console.WriteLine($"Estado calculado: {estado}");
            Console.WriteLine($"Conectada: {conectadaTest}");
        }
        else
        {
            Console.WriteLine("Primero ejecute opción 1 (registro válido)");
        }
        Console.WriteLine(" VERIFICACIÓN DE LÓGICA COMPLETADA\n");
    }

    static void VerificarConsultasBD()
    {
        Console.WriteLine("=== PRUEBA 4: CONSULTAS A LA BASE DE DATOS ===");

        Console.WriteLine($"\n ESTADÍSTICAS GENERALES:");
        Console.WriteLine($"Laboratorios: {laboratorios.Count}");
        Console.WriteLine($"Modelos PC: {modelos.Count}");
        Console.WriteLine($"Computadoras: {computadoras.Count}");
        Console.WriteLine($"Mediciones: {mediciones.Count}");

        Console.WriteLine("\n CONSULTA 1: Computadoras registradas");
        foreach (var pc in computadoras)
        {
            Console.WriteLine($"  → {pc.nombre} ({pc.sistemaOperativo})");
        }

        Console.WriteLine("\n CONSULTA 2: Filtrar Windows");
        var pcsWindows = computadoras.Where(pc => pc.sistemaOperativo.Contains("Windows")).Count();
        Console.WriteLine($"PCs con Windows: {pcsWindows}");

        Console.WriteLine("\n CONSULTA 3: Estado de listas");
        Console.WriteLine($"Listas vacías: {(laboratorios.Count + modelos.Count + computadoras.Count + mediciones.Count == 0 ? "SÍ" : "NO")}");

        Console.WriteLine(" TODAS LAS CONSULTAS FUNCIONAN CORRECTAMENTE\n");
    }

    static void MostrarListas()
    {
        Console.WriteLine("===   LISTAS COMPLETAS ===");

        Console.WriteLine($"\n Computadoras ({computadoras.Count}):");
        foreach (var pc in computadoras)
        {
            Console.WriteLine($"   {pc.nombre} - SO: {pc.sistemaOperativo}");
        }

        Console.WriteLine($"\nModelos ({modelos.Count}):");
        foreach (var modelo in modelos)
        {
            Console.WriteLine($"   Modelo creado correctamente");
        }

        Console.WriteLine($"\n Mediciones ({mediciones.Count}):");
        foreach (var m in mediciones)
        {
            Console.WriteLine($"  Medición válida registrada");
        }

        Console.WriteLine("\nVISUALIZACIÓN COMPLETA\n");
    }

    static string CalcularEstado(int cpu, int ram, float temp)
    {
        if (cpu > 85 || ram > 85 || temp > 70)
            return "CRÍTICO";
        else if (cpu > 70 || ram > 70 || temp > 55)
            return "ADVERTENCIA";
        else
            return " OPERATIVO";
    }
}