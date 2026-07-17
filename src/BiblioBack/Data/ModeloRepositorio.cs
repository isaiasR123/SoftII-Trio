using MySql.Data.MySqlClient;
using BiblioBack.Dominio;
using Dapper;

namespace BiblioBack.Data;

public class ModeloRepositorio
{
    private Conexion conexion = new Conexion();

    public void Agregar(ModeloPc modelo)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    INSERT INTO Modelo
    (idModelo, marca, modelo, procesador, ram)
    VALUES
    (@IdModelo, @Marca, @Modelo, @Procesador, @Ram)";

        conn.Execute(sql, modelo);
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