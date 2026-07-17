using MySql.Data.MySqlClient;
using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class ModeloRepositorio
{
    private Conexion conexion = new Conexion();

    public void Agregar(ModeloPc modelo)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"INSERT INTO Modelo
                       (idModelo, marca, modelo, procesador, ram)
                       VALUES
                       (@id, @marca, @modelo, @procesador, @ram)";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", modelo.IdModelo);
        cmd.Parameters.AddWithValue("@marca", modelo.Marca);
        cmd.Parameters.AddWithValue("@modelo", modelo.Modelo);
        cmd.Parameters.AddWithValue("@procesador", modelo.Procesador);
        cmd.Parameters.AddWithValue("@ram", modelo.Ram);

        cmd.ExecuteNonQuery();
    }

    public List<ModeloPc> ObtenerTodos()
    {
        return new List<ModeloPc>();
    }

    public ModeloPc? BuscarPorId(int id)
    {
        return null;
    }

    public void Actualizar(ModeloPc modelo)
    {

    }

    public void Eliminar(int id)
    {

    }
}