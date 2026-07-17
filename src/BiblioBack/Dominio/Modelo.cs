namespace BiblioBack.Dominio;

public class ModeloPc
{
    public int IdModelo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Procesador { get; set; }
    public int Ram { get; set; }

    public ModeloPc(int idModelo, string marca, string modelo, int procesador, int ram)
    {
        if (idModelo <= 0)
            throw new Exception("El ID del modelo debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(marca))
            throw new Exception("La marca es obligatoria.");

        if (string.IsNullOrWhiteSpace(modelo))
            throw new Exception("El modelo es obligatorio.");

        if (procesador <= 0)
            throw new Exception("El procesador debe ser mayor que cero.");

        if (ram <= 0)
            throw new Exception("La RAM debe ser mayor que cero.");

        IdModelo = idModelo;
        Marca = marca;
        Modelo = modelo;
        Procesador = procesador;
        Ram = ram;
    }
}