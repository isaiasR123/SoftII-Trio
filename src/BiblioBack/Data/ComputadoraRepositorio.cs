using MySql.Data.MySqlClient;
using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class ComputadoraRepositorio
{
    private Conexion conexion = new Conexion();


    public void Agregar(Computadora computadora)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    INSERT INTO Computadoras
    (idComputadora, idLaboratorio, idModelo, nombre_equipo)
    VALUES
    (@id, @lab, @modelo, @nombre)";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id", computadora.IdComputadora);
        cmd.Parameters.AddWithValue("@lab", computadora.IdLaboratorio);
        cmd.Parameters.AddWithValue("@modelo", computadora.IdModelo);
        cmd.Parameters.AddWithValue("@nombre", computadora.NombreEquipo);

        cmd.ExecuteNonQuery();
    }


    public List<Computadora> ObtenerTodas()
    {
        List<Computadora> lista = new();

        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
    SELECT 
        c.idComputadora,
        c.idLaboratorio,
        c.idModelo,
        c.nombre_equipo,
        m.marca,
        m.modelo,
        m.ram
    FROM Computadoras c
    INNER JOIN Modelo m 
    ON c.idModelo = m.idModelo";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        using MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Computadora pc = new Computadora(
                reader.GetString("marca"),
                reader.GetString("modelo"),
                reader.GetString("nombre_equipo"),
                reader.GetInt32("ram")
            );

            lista.Add(pc);
        }

        return lista;
    }


    public Computadora? BuscarPorCodigo(string codigo)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @" SELECT 
        c.nombre_equipo,
        m.marca,
        m.modelo,
        m.ram
        FROM Computadoras c
        INNER JOIN Modelo m ON c.idModelo = m.idModelo
        WHERE c.nombre_equipo = @codigo";

        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@codigo", codigo);

        using MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Computadora(
                reader.GetString("marca"),
                reader.GetString("modelo"),
                reader.GetString("nombre_equipo"),
                reader.GetInt32("ram")
            );
        }

        return null;
    }

    public void Actualizar(Computadora computadora)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
        UPDATE Modelo m
        INNER JOIN Computadoras c 
        ON m.idModelo = c.idModelo
        SET 
        m.marca = @marca,
        m.modelo = @modelo,
        m.ram = @ram
        WHERE c.nombre_equipo = @codigo";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@marca", computadora.Marca);
        cmd.Parameters.AddWithValue("@modelo", computadora.Modelo);
        cmd.Parameters.AddWithValue("@ram", computadora.Ram);
        cmd.Parameters.AddWithValue("@codigo", computadora.Codigo);

        cmd.ExecuteNonQuery();
    }


    public void Eliminar(string codigo)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "DELETE FROM Computadoras WHERE nombre_equipo = @codigo";

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@codigo", codigo);

        cmd.ExecuteNonQuery();
    }
}