
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/materials")]
[ApiController]
public class MaterialController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MaterialController(ApplicationDbContext context)
    {
        _context = context;
    }

  
[HttpGet]
public async Task<ActionResult<IEnumerable<MaterialDto>>> SearchMaterialsByName(string name, int page = 1, int pageSize = 10)
{
    var materials = await _context.Materials
        .Where(m => EF.Functions.ILike(m.MaterialName, $"%{name}%"))
        .OrderBy(m => m.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(m => new MaterialDto { Id = m.Id, MaterialName = m.MaterialName, FullName = m.FullName })
        .ToListAsync();

    return Ok(materials);
}

[HttpGet("{id}")]
public async Task<ActionResult<MaterialDto>> GetMaterialDetails(int id)
{
    var material = await _context.Materials
        .Where(m => m.Id == id)
        .Select(m => new MaterialDto { Id = m.Id, MaterialName = m.MaterialName, FullName = m.FullName })
        .FirstOrDefaultAsync();

    if (material == null)
        return NotFound();

    return Ok(material);
}

}
