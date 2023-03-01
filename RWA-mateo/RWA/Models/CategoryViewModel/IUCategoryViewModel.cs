using System.Collections.Generic;

namespace RWA.Models.CategoryViewModel
{
    public class IUCategoryViewModel
    {
        public bool IsInsert { get; set; }
        public Category Category { get; set; }
        

        public IUCategoryViewModel(bool isInsert, Category category)
        {
            IsInsert = isInsert;
            Category = category;
            
        }

        public string Title { 
            get
            {
                return IsInsert ? "Unos kategorije" : "Izmjena kategorije";
            }
        }

        public string ActionMetod
        {
            get
            {
                return IsInsert ? "InsertCategory" : "UpdateCategory";
            }
        }
    }
}