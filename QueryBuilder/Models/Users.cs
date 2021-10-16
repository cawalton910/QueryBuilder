using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    class Users : IClassModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string OtherUserDetails { get; set; }
        public string AmountOfFine { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Information()
        {
            return ($"ID: {Id}, Name: {UserName}, Address: {UserAddress}, Other details: {OtherUserDetails}, Fine amount: {AmountOfFine}, Email: {Email}, Phone: {PhoneNumber}");
        }
    }
}
