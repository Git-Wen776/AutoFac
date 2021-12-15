using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AucoFac.Service
{
    public class TestService : ITestService
    {
        public string ShowStr()
        {
            Console.WriteLine("正在测试");
            return "coco";
        }
    }
}
