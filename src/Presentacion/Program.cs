using BiblioBack.Dominio;
using MySql.Data.MySqlClient;
using proyecto;
namespace BiblioBack.presentacion;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Conexion db = new Conexion();

            using (MySqlConnection conn = db.ObtenerConexion())
            {
                Console.WriteLine("Conectado a MySQL correctamente");

                string sql = @"INSERT INTO laboratorio(nombre, ubicacion)
                               VALUES(@nombre,@ubicacion)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", "Laboratorio A");
                cmd.Parameters.AddWithValue("@ubicacion", "Primer Piso");

                cmd.ExecuteNonQuery();

                Console.WriteLine("Laboratorio guardado");
            }

            Laboratorio lab = new Laboratorio("Laboratorio A", "Primer Piso");

            ModeloPc modelo = new ModeloPc(
                "Dell",
                "OptiPlex 7090",
                75,
                16
            );

            Computadora pc = new Computadora(
                "PC-001",
                "Windows 11",
                lab,
                modelo
            );

            pc.MostrarInformacion();

            Console.WriteLine($"¿Está activa?: {pc.EstaActivo()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}