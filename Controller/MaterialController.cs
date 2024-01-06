
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

  
[HttpGet("{materialName}")]
public async Task<ActionResult<MaterialDto>> GetMaterial(string materialName)
{
    var material = await _context.Materials
        .Include(m => m.Products)
            .ThenInclude(p => p.Brand)
            .ThenInclude(b => b.Manufacturer)
        .FirstOrDefaultAsync(m => m.MaterialName == materialName);

    if (material == null)
    {
        return NotFound();
    }

    var materialDto = new MaterialDto
    {
        Id = material.Id,
        MaterialName = material.MaterialName,
        FullName = material.FullName,
        Products = material.Products.Select(p => new ProductDto
        {
            MaterialId = p.MaterialId,
            BrandTitle = p.Brand.Title,
            ManufacturerTitle = p.Brand.Manufacturer.Title,
            Cas = p.Cas,
            Ghg = p.Ghg,
            EnergyInput = p.EnergyInput,
            EuRegulation = p.EuRegulation,
            SupplyRisk = p.SupplyRisk,
            CriticalValue = p.CriticalValue
        }).ToList()
    };

    return Ok(materialDto);
}

}
