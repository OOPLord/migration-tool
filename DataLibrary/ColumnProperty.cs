using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class ColumnProperty
    {
        private string name;
        private string type;

        public ColumnProperty()
        { }

        public ColumnProperty(string columnName, string columnType)
        {
            this.name = columnName;
            this.type = columnType;
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
