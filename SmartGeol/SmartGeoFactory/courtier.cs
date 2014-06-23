using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartGeoFactory
{
    public class courtier
    {
        private int id;
        private int courtierid;
        private string email;
        private string password;
        private string title;
        private string lastname;
        private string firstname;
        private string website;
        private string city;
        private string country;
        private string company;
        private string phone;
        private string biography;
        private string specification;

        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }
  
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
  
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
  
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
  
        public string City
        {
            get { return city; }
            set { city = value; }
        }
  
        public string Website
        {
            get { return website; }
            set { website = value; }
        }
  
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
  
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
  
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
  
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
  
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
  
        public int Courtierid
        {
            get { return courtierid; }
            set { courtierid = value; }
        }
 
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
  
    }
}
