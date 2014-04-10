using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSIGlass.Web.ViewModels
{
    using Contract.Models;

    public class ProductListViewModel
    {
        public int CategoryId { get; set; }

        public IList<Product> Products { get; set; }        
    }

    public class ProductListRuViewModel
    {
        public int CategoryId { get; set; }

        public IList<ProductRu> Products { get; set; }
    }
}