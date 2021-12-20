using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFac.Models;
using AutoFac.Models.ViewModel;

namespace AutoFac.Extentions.AutoMapperConfig
{
    public class UserProfile:AutoMapperProfile<User,UserDto>
    {
    }
}
