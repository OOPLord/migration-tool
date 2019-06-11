using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class TableModel
    {
        private string name;
        private List<ColumnProperty> propertyCollection;

        public TableModel()
        { }

        public string Name { get => name; set => name = value; }
        public List<ColumnProperty> ColumnCollection { get => propertyCollection; set => propertyCollection = value; }
    }
}
