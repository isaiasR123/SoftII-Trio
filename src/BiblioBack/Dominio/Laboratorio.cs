namespace proyecto;

class Laboratorio
{
    private string nombre { get; set; }
    private string ubicacion { get; set; }

    public Laboratorio(string nombre, string ubicacion){
      ValidarLaboratorio.ValidarNombre(nombre);
        ValidarLaboratorio.ValidarUbicacion(ubicacion);

        this.nombre = nombre;
        this.ubicacion = ubicacion;
    }

   
}
