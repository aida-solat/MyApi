public class MaterialDto
{
    public int Id { get; set; }
    public string MaterialName { get; set; }
    public string FullName { get; set; }
    public List<ProductDto> Products { get; set; }
}