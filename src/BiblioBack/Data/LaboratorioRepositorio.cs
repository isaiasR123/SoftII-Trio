using MySql.Data.MySqlClient;
using proyecto;

namespace BiblioBack.Data;

public class LaboratorioRepositorio
{
    private readonly Conexion conexion = new Conexion();

    public void Guardar(Laboratorio laboratorio)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"INSERT INTO laboratorio(nombre, ubicacion)
                       VALUES(@nombre,@ubicacion)";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@nombre", laboratorio.Nombre);
        cmd.Parameters.AddWithValue("@ubicacion", laboratorio.Ubicacion);

        cmd.ExecuteNonQuery();
    }
}