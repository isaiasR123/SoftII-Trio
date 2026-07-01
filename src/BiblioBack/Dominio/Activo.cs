using System;
class Activo
{
    public string nombre {get; set;}
    public string descripcion {get; set;}
    public string fechaAdquisicion {get; set;}
    public string estado {get; set;}
    public string Ubicacion { get; set; }

    public Activo(string nombre, string descripcion, string fechaAdquisicion, string estado, string ubicacion)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.fechaAdquisicion = fechaAdquisicion;
        this.estado = estado;
        this.Ubicacion = ubicacion;
    }

    public virtual void mostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Descripción: " + descripcion);
        Console.WriteLine("Fecha de Adquisición: " + fechaAdquisicion);
        Console.WriteLine("Estado: " + estado);
        Console.WriteLine("Ubicación: " + Ubicacion);
    }

    public void cambiarEstado(string nuevoEstado)
    {
        estado = nuevoEstado;
        Console.WriteLine("El estado del activo ha sido cambiado a: " + estado);
    }

    public void cambiarUbicacion(string nuevaUbicacion)
    {
        Ubicacion = nuevaUbicacion;
        Console.WriteLine("La ubicación del activo ha sido cambiada a: " + Ubicacion);
    }
}