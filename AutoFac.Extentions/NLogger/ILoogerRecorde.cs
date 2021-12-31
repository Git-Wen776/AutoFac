using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Extentions.NLogger
{
    public interface ILoogerRecorde
    {
        void Debug(Type type,string ex);
        void Info(Type type,string ex);
        void Warn(Type type,string ex);
        void Error(Type type,string ex);    
    }
}
