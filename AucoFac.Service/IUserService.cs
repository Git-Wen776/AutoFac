using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFac.Repository;

namespace AucoFac.Service
{
    public interface IUserService
    {
        IEnumerable<UserModel> Query();
        UserModel Get(int id);
        IEnumerable<UserModel> Add(UserModel item);
    }
}
