using RWA.Models;
using System;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RWA.WebForms
{
    public partial class EditCustomer : System.Web.Mvc.ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customer = Repository.GetCustomer((int)Session["CustomerID"]);
            Ime.Value = customer.Ime;
            Prezime.Value = customer.Prezime;
            email.Value = customer.Email;
            Telefon.Value = customer.Telefon;
            var countryID = Repository.GetCountryID(customer.IDKupac);
            var towns = Repository.GetTowns(countryID[0]);
            foreach (var item in towns)
            {
                var newITem = new ListItem(item.Naziv, item.IDGrad.ToString());
                grad.Items.Add(newITem);
            }

        }

       
    }
}
