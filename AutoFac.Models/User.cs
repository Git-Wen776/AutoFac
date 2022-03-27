using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pwd { get; set; }
        public string ImgUrl { get; set; }
    }
}
