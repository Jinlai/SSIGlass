using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.Services
{
    using Contract.Models;
    using Contract.Services;
    using DataAccess;

    public class ProductRuService : ApplicationService<int, ProductRu, IProductRuDao>, IProductRuService
    {
        public ProductRuService(IProductRuDao dao)
            : base(dao)
        {

        }

        public IList<ProductRu> GetAll(int categoryId)
        {
            return Dao.GetAll(categoryId);
        }

        public IList<ProductRu> GetAll()
        {
            return Dao.GetAll();
        }
    }
}
