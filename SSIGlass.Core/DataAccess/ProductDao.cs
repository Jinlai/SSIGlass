using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract;
    using Contract.Models;

    public class ProductDao : MyBatisNetDao<int, Product>, IProductDao
    {
        public Product GetById(int id)
        {
            return SqlMap.QueryForObject<Product>("GetProductByProductId", id);
        }

        public int Create(Product instance)
        {
            return (int)SqlMap.Insert("InsertProduct", instance);
        }

        public bool Update(Product instance)
        {
            return SqlMap.Update("UpdateProductByProductId", instance) > 0;
        }

        public bool Delete(int id)
        {
            return SqlMap.Delete("DeleteProductByProductId", id) > 0;
        }

        public IList<Product> GetAll(ExtPaging paging, out int total)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll(ExtPaging paging)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll(int categoryId)
        {
            return SqlMap.QueryForList<Product>("GetProductByCategoryId", categoryId);
        }

        public IList<Product> GetAll()
        {
            return SqlMap.QueryForList<Product>("GetAllProductList", null);
        }
    }
}