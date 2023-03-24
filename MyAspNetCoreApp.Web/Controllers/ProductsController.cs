using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context)
        {
            //DI container creates the instance of the object
            _productRepository = new ProductRepository();

            _context= context;

            //Now, I do not need this part of code because I take all the datas from the user

            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() {Name = "Book 1", Price = 100, Stock = 100, Color = "Red" });
            //    _context.Products.Add(new Product() {Name = "Book 2", Price = 200, Stock = 200, Color = "Blue" });
            //    _context.Products.Add(new Product() {Name = "Book 3", Price = 300, Stock = 300, Color = "Grey" });
            //    _context.SaveChanges();
            //}
        }

        public IActionResult Index()
        {
            //I dont need to use GetAll method because Entity Framework has its own methods to do CRUD in SQL
            var products = _context.Products.ToList();
            //var products = _productRepository.GetAll();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            //I dont need to use Remove method 
            //_productRepository.Remove(id);

            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
           
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //data go within the request's body by using httpPost attribute which is
        //safer than sending in the request's header
        [HttpPost]
        public IActionResult Add(string Name, decimal Price, int Stock, string Color)
        {
            //1. way (not the best practise)
            //I take all the information from user without parameterless SaveProduct method

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //I give the parameters to SaveProduct method and create newProduct with this information
            Product newProduct = new Product(){Name = Name, Price = Price, Stock = Stock, Color = Color};

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
