using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.Services
{
    using Contract.Models;
    using Contract.Services;
    using DataAccess;

    public class ManagerService : ApplicationService<int, Manager, IManagerDao>, IManagerService
    {
        public ManagerService(IManagerDao dao)
            : base(dao)
        {

        }

        public Manager GetByUserName(string userName)
        {
            return Dao.GetByUserName(userName);
        }
    }
}
