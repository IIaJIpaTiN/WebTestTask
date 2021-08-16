using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactTest.Models
{
    public class UserFromClient
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public string DateUrl { get; set; }
    }
}
