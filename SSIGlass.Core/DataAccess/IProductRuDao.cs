using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract.Models;

    public interface IProductRuDao : IDao<int, ProductRu>
    {
        IList<ProductRu> GetAll(int categoryId);

        IList<ProductRu> GetAll();
    }
}
