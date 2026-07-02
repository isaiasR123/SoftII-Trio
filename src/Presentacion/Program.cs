using BiblioBack.Data;
using BiblioBack.Dominio;
using proyecto;

namespace proyecto;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Crear el laboratorio
            Laboratorio lab = new Laboratorio("Laboratorio A", "Primer Piso");

            // Guardarlo en la base de datos
            LaboratorioRepositorio repo = new LaboratorioRepositorio();
            repo.Guardar(lab);

            // Crear la computadora
            Computadora pc = new Computadora("Dell", "OptiPlex 7090", "PC-001", 16);

            Console.WriteLine("Sistema funcionando");
            pc.MostrarInformacion();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}