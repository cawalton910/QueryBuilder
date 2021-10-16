using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    class Books : IClassModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string DateOfPublication { get; set; }
    
        public Books(long i, string t, string s, string d)
        {
            Id = i;
            Title = t;
            Isbn = s;
            DateOfPublication = d;
        }

        public string Information()
        {
            return ($"ID: {Id}, Title: {Title}, Isbn: {Isbn}, Date of publication: {DateOfPublication}");
        }
    }

}
