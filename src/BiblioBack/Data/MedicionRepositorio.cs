using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class MedicionRepositorio
{
    public void Agregar(Medicion medicion) { }

    public List<Medicion> ObtenerTodas()
    {
        return new List<Medicion>();
    }

    public List<Medicion> ObtenerPorComputadora(int computadoraId)
    {
        return new List<Medicion>();
    }

    public void Eliminar(int id) { }
}