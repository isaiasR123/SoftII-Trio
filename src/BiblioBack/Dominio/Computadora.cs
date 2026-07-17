namespace BiblioBack.Dominio;

public class Computadora
{
    public int IdComputadora { get; set; }
    public int IdLaboratorio { get; set; }
    public int IdModelo { get; set; }

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }
    public string NombreEquipo { get; set; }
    public int Ram { get; set; }


    public Computadora(
        int idComputadora,
        int idLaboratorio,
        int idModelo,
        string nombreEquipo)
    {
        IdComputadora = idComputadora;
        IdLaboratorio = idLaboratorio;
        IdModelo = idModelo;
        NombreEquipo = nombreEquipo;
    }


    public Computadora(
        string marca,
        string modelo,
        string codigo,
        int ram)
    {
        Marca = marca;
        Modelo = modelo;
        Codigo = codigo;
        Ram = ram;
    }


    public void MostrarInformacion()
    {
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"RAM: {Ram}");
    }
}