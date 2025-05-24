using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project4.Models
{
    public class Teacher
    {
        public string Name { get; set; } = string.Empty;
        public override string ToString() => Name;
    }
}
