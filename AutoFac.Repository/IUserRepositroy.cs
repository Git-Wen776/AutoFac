using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Repository
{
    public interface IUserRepositroy
    {
        IEnumerable<UserModel> Query();
        UserModel Get(int id);
        IEnumerable<UserModel> Add(UserModel item);
    }
}
