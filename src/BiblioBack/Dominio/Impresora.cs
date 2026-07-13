using System;
using BiblioBack.Dominio;
namespace BiblioBack.Dominio;

public class Impresora : Activo, IActivo
{
    public string Tipo { get; set; }
    public bool Color { get; set; }

    public Impresora(
        string codigo,
        string marca,
        string modelo,
        string tipo,
        bool color
    ) : base(marca, modelo, codigo)
    {
        if(string.IsNullOrWhiteSpace(tipo))
        throw new Exception("El tipo de impresora es obligatorio.");

        Tipo = tipo;
        Color = color;
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Imprime en color: {Color}");
    }
}