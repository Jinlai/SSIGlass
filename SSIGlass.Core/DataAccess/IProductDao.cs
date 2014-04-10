using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract.Models;

    public interface IProductDao : IDao<int, Product>
    {
        IList<Product> GetAll(int categoryId);

        IList<Product> GetAll();
    }
}
