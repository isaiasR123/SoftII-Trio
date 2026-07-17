using MySql.Data.MySqlClient;
using BiblioBack.Dominio;

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

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", ObtenerNuevoId());
        cmd.Parameters.AddWithValue("@nombre", laboratorio.Nombre);
        cmd.Parameters.AddWithValue("@ubicacion", laboratorio.Ubicacion);

        cmd.ExecuteNonQuery();
    }

    private int ObtenerNuevoId()
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "SELECT IFNULL(MAX(idLaboratorio),0)+1 FROM Laboratorio";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        return Convert.ToInt32(cmd.ExecuteScalar());
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

        string sql = "SELECT nombre, ubicacion FROM Laboratorio WHERE nombre = @nombre";

        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nombre", nombre);

        using MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Laboratorio(
                reader.GetString("nombre"),
                reader.GetString("ubicacion")
            );
        }

        return null;
    }

    public void Actualizar(Laboratorio laboratorio)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    UPDATE Laboratorio
    SET ubicacion = @ubicacion
    WHERE nombre = @nombre";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@ubicacion", laboratorio.Ubicacion);
        cmd.Parameters.AddWithValue("@nombre", laboratorio.Nombre);

        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int idLaboratorio)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "DELETE FROM Laboratorio WHERE idLaboratorio = @id";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", idLaboratorio);

        cmd.ExecuteNonQuery();
    }
}