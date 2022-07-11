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
                Assembly.GetExecutingAssembly().GetTypes().
                Where(a => a.Name.EndsWith("Profile")).ToList().ForEach(_ =>
                {
                    p.AddProfile(_);
                });
                p.SourceMemberNamingConvention = new PascalCaseNamingConvention();
            });
        }
    }
}
