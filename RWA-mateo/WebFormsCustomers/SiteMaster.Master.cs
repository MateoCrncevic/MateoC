using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCustomers
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void PickedCustomer(string customer)
        {
            lblPickedCustomer.Text = customer;  
        }
        public void PickedBill(string bill)
        {
            lblPcikedBIll.Text = bill;
        }
    }
}