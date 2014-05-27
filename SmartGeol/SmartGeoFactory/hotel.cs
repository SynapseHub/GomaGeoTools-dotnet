using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Geol
{
    class hotel
    {
        private int id;
        private int idcity;
        private string title;
        private string type;
        private string url;
        private float longitude;
        private float latitude;
        private string adresse;
        private string deschotel;
        private int star;
        private int nbroom;
        private int nbroomdispo;
        private float roompricemin;
        private float roompricemax;
        private string mail;
        private string pictureurl;
            
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        
        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
       
        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        

        public string Deschotel
        {
            get { return deschotel; }
            set { deschotel = value; }
        }
        

        public int Star
        {
            get { return star; }
            set { star = value; }
        }
        

        public int Nbroom
        {
            get { return nbroom; }
            set { nbroom = value; }
        }
        
        public int Nbroomdispo
        {
            get { return nbroomdispo; }
            set { nbroomdispo = value; }
        }
        

        public float Roompricemin
        {
            get { return roompricemin; }
            set { roompricemin = value; }
        }
        

        public float Roompricemax
        {
            get { return roompricemax; }
            set { roompricemax = value; }
        }
        

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        

        public string Pictureurl
        {
            get { return pictureurl; }
            set { pictureurl = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Idcity
        {
            get { return idcity; }
            set { idcity = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
       
       
    }
}
