
namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "Book", Price = 10, Stock = 150 },
            new() { Id = 2, Name = "Pencil", Price = 7, Stock = 200 },
            new() { Id = 3, Name = "Eraser", Price = 5, Stock = 300 }
        };

        public List<Product> GetAll() => _products;
        public void Add(Product product) => _products.Add(product);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Product with this Id ({id}) is not found");
            }
            else
            {
                _products.Remove(hasProduct);
            }
        }

        public void Update(Product product)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == product.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Product2 with this Id ({product.Id}) is not found");
            }
            else
            {
                hasProduct.Name = product.Name;
                hasProduct.Stock = product.Stock;
                hasProduct.Price = product.Price;

                var index = _products.FindIndex(x => x.Id == product.Id);

                _products[index] = hasProduct;
            }
        }
    }
}
