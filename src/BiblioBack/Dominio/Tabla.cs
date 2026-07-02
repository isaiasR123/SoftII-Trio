using System;
using BiblioBack.Dominio;

public class Tabla : Activo, IActivo
{
    public int CantidadFilas { get; set; }
    public int CantidadColumnas { get; set; }

    public Tabla(
        string marca,
        string modelo,
        string codigo,
        int cantidadFilas,
        int cantidadColumnas
    ) : base(marca, modelo, codigo)
    {
        CantidadFilas = cantidadFilas;
        CantidadColumnas = cantidadColumnas;
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Filas: {CantidadFilas}");
        Console.WriteLine($"Columnas: {CantidadColumnas}");
    }
}