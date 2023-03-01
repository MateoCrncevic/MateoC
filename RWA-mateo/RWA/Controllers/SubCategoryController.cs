using RWA.Models;
using RWA.Models.SubCategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{
    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        public ActionResult Index()
        {
            var subcategories = Repository.GetSubCategories();   
            return View(subcategories);
        }


        [HttpGet]
        public ActionResult EditSubCategory(int id)
        {
            var subCategory = Repository.GetSubCategory(id);
            var categories = Repository.GetCategories();
            IUSubCategoryViewModel model = new IUSubCategoryViewModel(false, subCategory, categories);
            return View("IUSubCategory",model);

        }
        [HttpPost]
        public ActionResult EditSubCategory(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateSubCategory(subCategory);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditSubCategory");
            }
            
        }

        [HttpGet]
        public ActionResult InsertSubCategory()
        {
            SubCategory subCategory = new SubCategory();
            var categories = Repository.GetCategories();
            IUSubCategoryViewModel model = new IUSubCategoryViewModel(true, subCategory, categories);
            return View("IUSubCategory", model);

        }

        [HttpPost]
        public ActionResult InsertSubCategory(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                Repository.InsertSubCategory(subCategory);
                return RedirectToAction("Index");
            }
            return View("InsertSubCategory");
        }

        public ActionResult DeleteSubCategory(int id)
        {
            Repository.DeleteSubCategory(id);
            return RedirectToAction("Index");
        }
    }
}