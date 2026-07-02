namespace proyecto;

public class Laboratorio
{
    public string nombre { get; set; }
    public string ubicacion { get; set; }

    public Laboratorio(string nombre, string ubicacion){
      ValidarLaboratorio.ValidarNombre(nombre);
        ValidarLaboratorio.ValidarUbicacion(ubicacion);

        this.nombre = nombre;
        this.ubicacion = ubicacion;
    }
}
