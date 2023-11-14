using ArticulosAPI.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IArticuloRepositorio
{
    Task<IEnumerable<ArticuloDto>> ObtenerArticulos();

    Task<ArticuloDto> ObtenerArticuloPorId(int id);

    Task AgregarArticulo(ArticuloDto articulo);

    Task ActualizarArticulo(int id, ArticuloDto articulo);

    Task EliminarArticulo(int id);
}
