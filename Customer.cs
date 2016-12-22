using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Customer
    {
        private string _Id;
        private string _FirstName;
        private string _LastName;
        private string _EmailAddress;
        private string _Address;
        private string _Phone;

        public Customer(string id, string firstName, string lastName)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
        }
        public Customer(string id, string firstName, string lastName, string emailAddress, string address, string phone)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
            this._EmailAddress = emailAddress;
            this._Address = address;
            this._Phone = phone;
        }



    }
}
