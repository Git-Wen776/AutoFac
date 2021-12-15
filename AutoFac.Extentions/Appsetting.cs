using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace AutoFac.Extentions
{
    public class Appsetting
    {
        private string _configPath;
        private static IConfiguration _config;

        public Appsetting(IConfiguration confing)
        {
            _config = confing;
        }

        public static string Bind(params string[] strs)
        {
            return _config.GetSection(string.Join(':', strs)).Value;
        }

        public T GetTentity<T>(string[] strs)
        {
            T t = default(T);
            var s = string.Join(':', strs);
            
            return t;
        }
    }
}
