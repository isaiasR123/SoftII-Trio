using MySql.Data.MySqlClient;

namespace BiblioBack.Data;

public class Conexion
{
    private string cadenaConexion =
    "Server=localhost;Database=5to_Monitoreo;Uid=5to_agbd;Pwd=Trigg3rs!;";
    
    public MySqlConnection ObtenerConexion()
    {
        MySqlConnection conn = new MySqlConnection(cadenaConexion);
        conn.Open();
        return conn;
    }
}