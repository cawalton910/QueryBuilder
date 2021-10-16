using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    class Author : IClassModel
    {
        public long Id { get; set; }
        public string FirstName {  get; set; }
        public string Surname { get; set; }

        public Author()
        {

        }
        public Author(long idd, string first, String last)
        {
            Id = idd;
            FirstName = first;
            Surname = last;
        }
        public string Information()
        {
            return ($"ID: {Id}, {FirstName} {Surname}");
        }
    }
    
}
