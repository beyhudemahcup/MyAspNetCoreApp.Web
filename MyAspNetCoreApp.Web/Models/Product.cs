namespace MyAspNetCoreApp.Web.Models
{
    //if we use different db table name in AppDbContext class, we should show 
    //in this class as a attribute

    //[Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Color { get; set; }
    }
}