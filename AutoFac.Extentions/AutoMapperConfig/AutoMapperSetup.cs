using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Extentions.AutoMapperConfig
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection service)
        {
            
            service.AddAutoMapper(p =>
            {
                var profiles = Assembly.GetExecutingAssembly().GetTypes().
                Where(p => p.BaseType == typeof(AutoMapperProfile<,>) && p.Name.EndsWith("Profile"));
                foreach (var profile in profiles)
                {
                    p.AddProfile(profile);
                }

                p.AddProfile<UserProfile>();
                p.SourceMemberNamingConvention = new PascalCaseNamingConvention();
            });
        }
    }
}
