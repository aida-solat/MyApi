public class Brand
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public string Title { get; set; }
    public List<Product> Products { get; set; }
}