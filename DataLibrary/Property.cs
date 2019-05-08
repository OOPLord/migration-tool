using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Property
    {
        private string name;
        private string type;

        public Property()
        { }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
