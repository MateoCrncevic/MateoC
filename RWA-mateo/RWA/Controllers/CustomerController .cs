using RWA.Models;
using RWA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA.Controllers
{

    public class CustomerController : Controller
    {

        public ActionResult Index()
        {
            var model = Repository.GetCountries();
            return View(model);
        }
        public ActionResult GetFilteredCustomers(FilterModel filterModel)
        {

            if (filterModel.CustomersPerPage == 0)
            {
                filterModel.CustomersPerPage = 10;
            }
            if (filterModel.Page==0)
            {
                filterModel.Page = 1;
            }
            var model = new ShowCustomersVM
            {
                CustomersPerOnePage=filterModel.CustomersPerPage,
                SortByType = (int)filterModel.SortByType,
                Countries = Repository.GetCountries(),
                Towns = Repository.GetTowns(filterModel.IDDrzava),
                Customers = Repository.GetCustomers(filterModel.IDDrzava, filterModel.IDGrad, filterModel.SortByType, filterModel.CustomersPerPage, filterModel.Page),
                Page = filterModel.Page
            };


            return View(model);
        }
        [HttpGet]
        public PartialViewResult ShowCustomerBills(int id)
        {
            var bills = Repository.GetCustomersBills(id);
            return PartialView("_ShowCustomerBills",bills);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            Session["CustomerID"] = id;
            return View();
        }
        

        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            customer.IDKupac = (int)Session["CustomerID"];
            Repository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }



        public PartialViewResult ShowStavke(int id)
        {
            var stavke = Repository.GetStavke(id);
            return PartialView("_ShowStavke",stavke);

        }
    }
}