using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Repository
{
    public class UserRepository:IUserRepositroy
    {
        IEnumerable<UserModel> _users = new List<UserModel>()
        {
            new UserModel(){Id=1,Name="xiaohuilin",Age=19},
            new UserModel(){Id=2,Name="xiaolin",Age=19},
            new UserModel(){Id=3,Name="xiaowen",Age=20}
        };
        public IEnumerable<UserModel> Add(UserModel item)
        {
            return _users.Append(item);
        }

        public UserModel Get(int id)
        {
           return _users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<UserModel> Query()
        {
           return _users;
        }
    }
}
