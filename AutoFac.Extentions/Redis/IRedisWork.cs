using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Extentions.Redis
{
    public interface IRedisWork
    {
        IDatabase _redisDb { get;}
        bool IsConnected();
        void ChangeDb(int index);
    }
}
