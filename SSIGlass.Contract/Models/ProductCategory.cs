using System.Collections.Generic;
using System.Linq;

namespace SSIGlass.Contract.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public static IList<ProductCategory> AllCategories = new List<ProductCategory>
                                                                 {
                                                                     new ProductCategory{CategoryId = 1001,CategoryName = "Aluminium Spacer Bar"},
                                                                     new ProductCategory{CategoryId = 1002,CategoryName = "Warm Spacer Bar"},
                                                                     new ProductCategory{CategoryId = 1003,CategoryName = "Molecular Sieve"},
                                                                     new ProductCategory{CategoryId = 1004,CategoryName = "Sealant for IG"}
                                                                 };

        public static ProductCategory GetById(int categoryId)
        {
            return AllCategories.First(x => x.CategoryId == categoryId);
        }
    }
}
