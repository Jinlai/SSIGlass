using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Services
{
    using Models;

    public interface IManagerService : IApplicationService<int, Manager>
    {
        Manager GetByUserName(string userName);
    }
}