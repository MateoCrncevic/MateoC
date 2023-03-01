using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebFormsCustomers.Models
{
    public class Repository
    {
        private string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public DataSet ds { get; set; }

        public List<Customer> GetCustomers()
        {

        }

    }
}