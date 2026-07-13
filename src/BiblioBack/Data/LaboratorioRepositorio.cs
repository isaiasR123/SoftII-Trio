using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class LaboratorioRepositorio
{
    public void Agregar(Laboratorio laboratorio) { }

    public List<Laboratorio> ObtenerTodos()
    {
        return new List<Laboratorio>();
    }

    public Laboratorio? BuscarPorId(int id)
    {
        return null;
    }

    public void Actualizar(Laboratorio laboratorio) { }

    public void Eliminar(int id) { }
}