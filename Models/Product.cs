public class Product
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int MaterialId { get; set; }
    public string? Cas { get; set; }
    public decimal? Ghg { get; set; }
    public decimal? EnergyInput { get; set; }
    public int? EuRegulation { get; set; }
    public int? SupplyRisk { get; set; }
    public decimal? CriticalValue { get; set; }
    public Material Material { get; set; }
    public Brand Brand { get; set; }
}