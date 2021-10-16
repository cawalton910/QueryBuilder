using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    class Books_Categories :IClassModel 
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public long CategoryId { get; set; }

        public string Information()
        {
            return ($"ID: {Id}, Book Id: {BookId}, Category Id: {CategoryId}");
        }
    }
}
