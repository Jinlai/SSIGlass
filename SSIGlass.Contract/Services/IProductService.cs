using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Services
{
    using Models;

    public interface IProductService : IApplicationService<int, Product>
    {
        IList<Product> GetAll(int categoryId);

        IList<Product> GetAll();
    }
}