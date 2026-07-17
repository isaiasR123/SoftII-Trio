using MySql.Data.MySqlClient;
using BiblioBack.Dominio;
using Dapper;

namespace BiblioBack.Data;

public class LaboratorioRepositorio
{
    private Conexion conexion = new Conexion();

    public void Agregar(Laboratorio laboratorio)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    INSERT INTO Laboratorio
    (idLaboratorio, nombre, ubicacion)
    VALUES
    (@id, @nombre, @ubicacion)";

        conn.Execute(sql, new
        {
            id = ObtenerNuevoId(),
            nombre = laboratorio.Nombre,
            ubicacion = laboratorio.Ubicacion
        });
    }

    public int ObtenerNuevoId()
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "SELECT IFNULL(MAX(idLaboratorio),0)+1 FROM Laboratorio";

        return conn.ExecuteScalar<int>(sql);
    }

    public List<Laboratorio> ObtenerTodos()
    {
        List<Laboratorio> lista = new();

        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "SELECT idLaboratorio, nombre, ubicacion FROM Laboratorio";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        using MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Laboratorio laboratorio = new Laboratorio(
                reader.GetString("nombre"),
                reader.GetString("ubicacion")
            );

            lista.Add(laboratorio);
        }

        return lista;
    }

    public Laboratorio? BuscarPorNombre(string nombre)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    SELECT
        nombre AS Nombre,
        ubicacion AS Ubicacion
    FROM Laboratorio
    WHERE nombre = @nombre";

        return conn.QueryFirstOrDefault<Laboratorio>(sql, new { nombre });
    }
    public void Actualizar(Laboratorio laboratorio)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    UPDATE Laboratorio
    SET ubicacion = @Ubicacion
    WHERE nombre = @Nombre";

        conn.Execute(sql, laboratorio);
    }

    public void Eliminar(int idLaboratorio)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "DELETE FROM Laboratorio WHERE idLaboratorio = @idLaboratorio";

        conn.Execute(sql, new { idLaboratorio });
    }
}