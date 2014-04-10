using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.Services
{
    using Contract.Models;
    using Contract.Services;
    using DataAccess;

    public class ProductService : ApplicationService<int, Product, IProductDao>, IProductService
    {
        public ProductService(IProductDao dao)
            : base(dao)
        {

        }

        public IList<Product> GetAll(int categoryId)
        {
            return Dao.GetAll(categoryId);
        }

        public IList<Product> GetAll()
        {
            return Dao.GetAll();
        }
    }
}
