using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Models
{
    public class PageModel
    {
        public int Size { get; set; } = 10;
        public int Page { get; set; } = 1;
        public int Total { get; set; }
    }
}
