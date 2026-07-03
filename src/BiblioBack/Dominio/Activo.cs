namespace BiblioBack.Dominio;

public abstract class Activo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }

    public Activo(string marca, string modelo, string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        throw new Exception("El código es obligatorio.");

        if (string.IsNullOrWhiteSpace(marca))
        throw new Exception("La marca es obligatoria.");

        if (string.IsNullOrWhiteSpace(modelo))
        throw new Exception("El modelo es obligatorio.");

        this.Marca = marca;
        this.Modelo = modelo;
        this.Codigo = codigo;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Código: {Codigo}");
    }
}