using System;
using System.Collections.Generic;
using System.Linq;

namespace SSIGlass.Core.DataAccess
{
    using Contract;
    using Contract.Models;

    public class ManagerDao : MyBatisNetDao<int, Manager>, IManagerDao
    {
        public Manager GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(Manager instance)
        {
            throw new NotImplementedException();
        }

        public bool Update(Manager instance)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Manager> GetAll(ExtPaging paging, out int total)
        {
            throw new NotImplementedException();
        }

        public IList<Manager> GetAll(ExtPaging paging)
        {
            throw new NotImplementedException();
        }

        public Manager GetByUserName(string userName)
        {
            return SqlMap.QueryForObject<Manager>("GetManagerByUserName", userName);
        }
    }
}