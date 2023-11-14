using Microsoft.AspNetCore.Mvc;
using ArticulosAPI.Modelos;
using ArticulosAPI.Dto;

[Route("api/[controller]")]
[ApiController]
public class ArticulosController : ControllerBase
{
    private readonly IArticuloRepositorio _articuloRepositorio;

    public ArticulosController(IArticuloRepositorio articuloRepositorio)
    {
        _articuloRepositorio = articuloRepositorio;
    }

    // GET: api/Articulos
    [HttpGet]
    public IActionResult GetArticulos()
    {
        var articulos = _articuloRepositorio.ObtenerArticulos();
        return Ok(articulos);
    }

    // GET: api/Articulos/5
    [HttpGet("{id}")]
    public IActionResult GetArticulo(int id)
    {
        var articulo = _articuloRepositorio.ObtenerArticuloPorId(id);

        if (articulo == null)
        {
            return NotFound();
        }

        return Ok(articulo);
    }

    // PUT: api/Articulos/5
    [HttpPut("{id}")]
    public IActionResult PutArticulo(int id, ArticuloDto articulo)
    {
        if (id != articulo.Id)
        {
            return BadRequest();
        }

        _articuloRepositorio.ActualizarArticulo(id, articulo);
        return NoContent();
    }

    // POST: api/Articulos
    [HttpPost]
    public IActionResult PostArticulo(ArticuloDto articulo)
    {
        _articuloRepositorio.AgregarArticulo(articulo);
        return CreatedAtAction("GetArticulo", new { id = articulo.Id }, articulo);
    }

    // DELETE: api/Articulos/5
    [HttpDelete("{id}")]
    public IActionResult DeleteArticulo(int id)
    {
        var articulo = _articuloRepositorio.ObtenerArticuloPorId(id);

        if (articulo == null)
        {
            return NotFound();
        }

        _articuloRepositorio.EliminarArticulo(id);
        return NoContent();
    }
}
