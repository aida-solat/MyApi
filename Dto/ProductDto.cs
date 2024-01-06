public class ProductDto
{
    public int MaterialId { get; set; }
    public string BrandTitle { get; set; }
    public string ManufacturerTitle { get; set; }
    public string? Cas { get; set; }
    public decimal? Ghg { get; set; }
    public decimal? EnergyInput { get; set; }
    public int? EuRegulation { get; set; }
    public int? SupplyRisk { get; set; }
    public decimal? CriticalValue { get; set; }
}