using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{

    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Text from ViewBag.name method";

            ViewData["Age"] = 55;
            ViewData["Names"] = new List<string>() { "jamie", "jack", "ferdinard" };
            ViewData["Text"] = "comes from ViewData method";

            ViewBag.person = new { Id = 1, Name = "Henry", Age = 34 };

            return View();
        }

        public IActionResult Index2()
        {
            //used the tempData to send variable to index1
            TempData["Surname"] = "lynn";
            //Asp.net read the tempData and move the variable to the index1 page if I go to index2 page

            //database adding process
            return RedirectToAction("Index", "example");
            //return View();
        }
        public IActionResult Index3()
        {
            var productList = new List<Product2>()
            {
                new(){Id = 1, Name= "Table" },
                new(){Id = 2, Name= "Spoon" },
                new(){Id = 3, Name= "Fork" }
            };

            return View(productList);
        }

        public IActionResult ParameterView(int id)
        {
            return RedirectToAction("JsonResultParameters", "example", new { id = id });
        }
        public IActionResult JsonResultParameters(int id)
        {
            return Json(new { Id = id });
        }

        //we can create another methods to return different datas
        public IActionResult ContentResult()
        {
            return Content("This is content message");
        }

        //returns json
        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, Name = "Burger", Price = 100 });
        }

        //returns blank page
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
