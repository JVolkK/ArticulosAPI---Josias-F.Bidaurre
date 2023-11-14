using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class ArticuloRepositorio : IArticuloRepositorio
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ArticuloRepositorio(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArticuloDto>> ObtenerArticulos()
    {
        var articulos = await _context.Articulos.ToListAsync();
        return articulos.Select(a => _mapper.Map<ArticuloDto>(a));
    }

    public async Task<ArticuloDto> ObtenerArticuloPorId(int id)
    {
        var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.Id == id);
        return _mapper.Map<ArticuloDto>(articulo);
    }

    public async Task AgregarArticulo(ArticuloDto articuloDto)
    {
        var articulo = _mapper.Map<Articulo>(articuloDto);

        _context.Articulos.Add(articulo);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarArticulo(int id, ArticuloDto articuloDto)
    {
        var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.Id == id);

        if (articulo != null)
        {
            _mapper.Map(articuloDto, articulo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task EliminarArticulo(int id)
    {
        var articulo = await _context.Articulos.FirstOrDefaultAsync(a => a.Id == id);
        _context.Articulos.Remove(articulo);
        await _context.SaveChangesAsync();
    }
}
