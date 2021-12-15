using AutoFac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AucoFac.Service
{
    public class UserServiceLpm : IUserService
    {
        private readonly IUserRepositroy repositroy;
        public UserServiceLpm(IUserRepositroy _repsoitory)
        {
            repositroy = _repsoitory;
        }

        public IEnumerable<UserModel> Add(UserModel item)
        {
            return repositroy.Add(item);
        }

        public UserModel Get(int id)
        {
            return repositroy.Get(id);
        }

        public IEnumerable<UserModel> Query()
        {
           return  repositroy.Query();
        }
    }
}
