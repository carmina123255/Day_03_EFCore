using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    internal class Address
    {
        public int BlockNumber { get; set; }
        public string? street { get; set; }
        public string? city { get; set; }
        public string? Country { get; set; }
    }
}
