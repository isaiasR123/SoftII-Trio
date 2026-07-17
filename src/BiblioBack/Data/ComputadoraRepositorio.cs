using MySql.Data.MySqlClient;
using BiblioBack.Dominio;
using Dapper;

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
        (@IdComputadora, @IdLaboratorio, @IdModelo, @NombreEquipo)";

        conn.Execute(sql, computadora);
    }

    public List<Computadora> ObtenerTodas()
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
        SELECT
            c.idComputadora AS IdComputadora,
            c.idLaboratorio AS IdLaboratorio,
            c.idModelo AS IdModelo,
            c.nombre_equipo AS Codigo,
            m.marca AS Marca,
            m.modelo AS Modelo,
            m.ram AS Ram
        FROM Computadoras c
        INNER JOIN Modelo m
        ON c.idModelo = m.idModelo";

        return conn.Query<Computadora>(sql).ToList();
    }

    public Computadora? BuscarPorCodigo(string codigo)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
        SELECT
            c.idComputadora AS IdComputadora,
            c.idLaboratorio AS IdLaboratorio,
            c.idModelo AS IdModelo,
            c.nombre_equipo AS Codigo,
            m.marca AS Marca,
            m.modelo AS Modelo,
            m.ram AS Ram
        FROM Computadoras c
        INNER JOIN Modelo m
        ON c.idModelo = m.idModelo
        WHERE c.nombre_equipo = @codigo";

        return conn.QueryFirstOrDefault<Computadora>(sql, new { codigo });
    }

    public void Actualizar(Computadora computadora)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = @"
        UPDATE Modelo m
        INNER JOIN Computadoras c
        ON m.idModelo = c.idModelo
        SET
            m.marca = @Marca,
            m.modelo = @Modelo,
            m.ram = @Ram
        WHERE c.nombre_equipo = @Codigo";

        conn.Execute(sql, computadora);
    }

    public void Eliminar(string codigo)
    {
        using MySqlConnection conn = conexion.ObtenerConexion();

        string sql = "DELETE FROM Computadoras WHERE nombre_equipo = @codigo";

        conn.Execute(sql, new { codigo });
    }
}