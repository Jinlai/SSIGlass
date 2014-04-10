using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract;
    using Contract.Models;

    public class ProductRuDao : MyBatisNetDao<int, ProductRu>, IProductRuDao
    {
        public ProductRu GetById(int id)
        {
            return SqlMap.QueryForObject<ProductRu>("GetProductRuByProductId", id);
        }

        public int Create(ProductRu instance)
        {
            return (int)SqlMap.Insert("InsertProductRu", instance);
        }

        public bool Update(ProductRu instance)
        {
            return SqlMap.Update("UpdateProductRuByProductId", instance) > 0;
        }

        public bool Delete(int id)
        {
            return SqlMap.Delete("DeleteProductRuByProductId", id) > 0;
        }

        public IList<ProductRu> GetAll(ExtPaging paging, out int total)
        {
            throw new NotImplementedException();
        }

        public IList<ProductRu> GetAll(ExtPaging paging)
        {
            throw new NotImplementedException();
        }

        public IList<ProductRu> GetAll(int categoryId)
        {
            return SqlMap.QueryForList<ProductRu>("GetProductRuByCategoryId", categoryId);
        }

        public IList<ProductRu> GetAll()
        {
            return SqlMap.QueryForList<ProductRu>("GetAllProductRuList", null);
        }
    }
}