using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class ClassModel
    {
        private string name;
        private Property[] propertyCollection;

        public ClassModel()
        { }

        public string Name { get => name; set => name = value; }
        public Property[] PropertyCollection { get => propertyCollection; set => propertyCollection = value; }
    }
}
