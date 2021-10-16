using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    class BooksOutOnLoan :IClassModel
    {
        public long Id { get; set; }
        public string BookId { get; set; }
        public string DateIssued { get; set; }
        public string DueDate { get; set; }
        public string DateReturned { get; set; }

        public string Information()
        {
            return ($"ID: {Id}, Book Id: {BookId}, Date Issued: {DateIssued}, Due Date: {DueDate}, Date Returned: {DateReturned}");
        }
    }
}
