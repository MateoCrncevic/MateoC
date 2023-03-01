using RWA.Models;
using RWA.Models.ProductViewModel;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = Repository.GetProducts();   
            return View(products);
        }


        [HttpGet]
        public ActionResult EditProduct(int id)
        {

            var product = Repository.GetProduct(id);
            var subCategories = Repository.GetSubCategories();
            IUProductViewModel model = new IUProductViewModel(false,product,subCategories);
            return View("IUProduct", model);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
                Repository.UpdateProduct(product);
                return RedirectToAction("Index");           
            
        }


        [HttpGet]
        public ActionResult InsertProduct()
        {
            var product = new Product();
            var subCategories = Repository.GetSubCategories();
            IUProductViewModel model = new IUProductViewModel(true, product, subCategories);
            return View("IUProduct", model);

        }

        [HttpPost]
        public ActionResult InsertProduct(Product product)
        {
            Repository.InsertProduct(product);
            return RedirectToAction("Index");
        }
          
        public ActionResult DeleteProduct(int id)
        {
            Repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}