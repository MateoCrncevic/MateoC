using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class FilterModel
    {
        public int? IDGrad { get; set; }
        public int IDDrzava { get; set; }
        public SortType SortByType { get; set; }

        public int CustomersPerPage { get; set; }

        public int Page { get; set; }

    }
}