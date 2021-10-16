using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    class Categories : IClassModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Information()
        {
            return ($"ID: {Id}, Name: {Name}");
        }
    }
}
