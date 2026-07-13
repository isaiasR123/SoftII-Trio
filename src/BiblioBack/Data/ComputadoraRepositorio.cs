using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class ComputadoraRepositorio
{
    public void Agregar(Computadora computadora) { }

    public List<Computadora> ObtenerTodas()
    {
        return new List<Computadora>();
    }

    public Computadora? BuscarPorCodigo(string codigo)
    {
        return null;
    }

    public void Actualizar(Computadora computadora) { }

    public void Eliminar(string codigo) { }
}