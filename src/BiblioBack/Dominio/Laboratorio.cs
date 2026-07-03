public class Laboratorio
{
    public string Nombre { get; set; }

    public string Ubicacion { get; set; }

    public Laboratorio(string nombre,string ubicacion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        throw new Exception("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(ubicacion))
        throw new Exception("La ubicación es obligatoria.");

        Nombre = nombre;
        Ubicacion = ubicacion;
    }
}