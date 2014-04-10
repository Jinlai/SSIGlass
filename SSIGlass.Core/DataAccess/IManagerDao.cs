using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract.Models;

    public interface IManagerDao : IDao<int, Manager>
    {
        Manager GetByUserName(string userName);
    }
}
