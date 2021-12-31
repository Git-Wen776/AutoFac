using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace AutoFac.Extentions
{
    public class Appsetting
    {
        private readonly IConfiguration Config;

        public Appsetting(IConfiguration _config)
        {
            Config = _config;
        }

        public Appsetting()
        {
            string path = "appsetting.json";
            Config = new ConfigurationBuilder().
                SetBasePath(@"E:\vs 2019\BookStore\Book.API\").
                Add(new JsonConfigurationSource
                {
                    Path = path,
                    Optional = false,
                    ReloadOnChange = true
                }).Build();
        }

        public  string settingStr(params string[] settings)
        {
            if(settings is null)
                throw new ArgumentNullException(nameof(settings));
            var section = string.Join(':', settings);
            return Config.GetSection(section).Value;
        }

        public  List<T> GetValues<T>(string[] param)
        {
            if (param is null)
                throw new ArgumentNullException(nameof(param));
            List<T> list = new List<T>();
            Config.Bind(string.Join(':', param), list);
            return list;
        }

        public  T GetObject<T>(string[] param)
        {
            if (param is null)
                throw new ArgumentNullException(nameof(param));
            T t = default;
            Config.Bind(string.Join(':', param), t);
            return t;
        }
    }

    public static class AppsettingSetUp
    {
        public static void AddAppsettingSetup(this IServiceCollection services)
        {
            services.AddSingleton<Appsetting>();
        }
    }
}
