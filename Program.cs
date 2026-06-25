using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace proyecto;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Laboratorio lab = new Laboratorio("Laboratorio A","Primer Piso");

            ModeloPc modelo = new ModeloPc("Dell", "OptiPlex 7090", 75, 16);

            Computadora pc = new Computadora("PC-001","Windows 11",lab,modelo);

            Console.WriteLine("Sistema funcionando");
            Console.WriteLine(pc.nombre);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}