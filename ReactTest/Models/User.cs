using ReactTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserList.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public byte[] Image { get; set; }
        public string ImageHeader { get; set; }
    }
}
