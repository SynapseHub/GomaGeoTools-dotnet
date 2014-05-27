using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Geol
{
    class users
    {
        private int userid;
        private string usern;
        private string pswd;
        private string type_acc;
        private string email;
        private string title;
        private string lastname;
        private string firstname;
        private string website;
        private string city;
        private string country;
        private string company;
        private string phone;
        private string biography;

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
  
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
  
        public string Type_acc
        {
            get { return type_acc; }
            set { type_acc = value; }
        }
  
        public string Pswd
        {
            get { return pswd; }
            set { pswd = value; }
        }
  
        public string Usern
        {
            get { return usern; }
            set { usern = value; }
        }
 
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
  
    }
}
