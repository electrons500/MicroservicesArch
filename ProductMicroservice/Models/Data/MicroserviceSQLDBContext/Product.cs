namespace ProductMicroservice.Models.Data.MicroserviceSQLDBContext;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal ProductPrice { get; set; }

    public string ProductDesc { get; set; }
}
