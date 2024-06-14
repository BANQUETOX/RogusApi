using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Person
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string secondLastName { get; set; }  
        public DateOnly birthday { get; set; }  
    }
}
