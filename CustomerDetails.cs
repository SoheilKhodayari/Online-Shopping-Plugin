using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class CustomerDetails
    {
        private string _Id;
        private string _FirstName;
        private string _LastName;
        private string _EmailAddress;
        private string _Address;
        private string _Phone;

        public CustomerDetails(string id, string firstName, string lastName)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
        }
        public CustomerDetails(string id, string firstName, string lastName, string emailAddress, string address, string phone)
        {
            this._Id = id;
            this._FirstName = firstName;
            this._LastName = lastName;
            this._EmailAddress = emailAddress;
            this._Address = address;
            this._Phone = phone;
        }
        public string getId()
        {
            return this._Id;
        }
        public void setId(string id)
        {
            this._Id = id;
        }
        public string getFirstName()
        {
            return this._FirstName;
        }
        public void setFirstName(string firstName)
        {
            this._FirstName = firstName;
        }
        public string getLastName()
        {
            return this._LastName;
        }
        public void setLastName(string lastName)
        {
            this._LastName = lastName;
        }
        public string getPhoneNumber()
        {
            return this._Phone;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this._Phone = phoneNumber;
        }
        public string getEmailAddress()
        {
            return this._EmailAddress;
        }
        public void setEmailAddress(string emailAddress)
        {
            this._EmailAddress = emailAddress;
        }
        public string getAddress()
        {
            return this._Address;
        }
        public void setAddress(string address)
        {
            this._Address = address;
        }


    }
}
