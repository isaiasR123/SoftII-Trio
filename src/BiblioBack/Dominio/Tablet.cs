using System;
using BiblioBack.Dominio;

public class Tablet : Activo, IActivo
{
    public int CantidadFilas { get; set; }
    public int CantidadColumnas { get; set; }

    public Tablet(
        string marca,
        string modelo,
        string codigo,
        int cantidadFilas,
        int cantidadColumnas
    ) : base(marca, modelo, codigo)
    {
        if (cantidadFilas <= 0)
        throw new Exception("La cantidad de filas debe ser mayor que cero.");

        if (cantidadColumnas <= 0)
        throw new Exception("La cantidad de columnas debe ser mayor que cero.");

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