using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models.ProductViewModel
{
    public class IUProductViewModel
    {
        public bool IsInsert { get; set; }
        public Product Product { get; set; }

        public List<SubCategory> SubCategories { get; set; }


        public IUProductViewModel(bool isInsert, Product product, List<SubCategory> subCategories)
        {
            IsInsert = isInsert;
            Product = product;
            SubCategories = subCategories;
        }

        public string Title
        {
            get
            {
                return IsInsert ? "Unos proizvoda" : "Izmjena proizvoda";
            }
        }

        public string ActionMetod
        {
            get
            {
                return IsInsert ? "InsertProduct" : "EditProduct";
            }
        }

    }
}