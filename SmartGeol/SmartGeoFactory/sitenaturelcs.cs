using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartGeoFactory
{
    public class sitenaturelcs
    {
        private int id;
        private int idsite;
        private int idcity;
        private string title;
        private string type;
        private float area;
        private string sitedesc;
        private float latitude;
        private float longitude;
        private string attractourist;
        private float largeur;
        private float longueur;
        private string security;
        private int visitorperan;
        private string site_url_image;

        public string Site_url_image
        {
            get { return site_url_image; }
            set { site_url_image = value; }
        }
        public int Visitorperan
        {
            get { return visitorperan; }
            set { visitorperan = value; }
        }
  
        public string Security
        {
            get { return security; }
            set { security = value; }
        }
  
        public float Longueur
        {
            get { return longueur; }
            set { longueur = value; }
        }
  
        public float Largeur
        {
            get { return largeur; }
            set { largeur = value; }
        }
  
        public string Attractourist
        {
            get { return attractourist; }
            set { attractourist = value; }
        }
  
        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
 
        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
  
        public string Sitedesc
        {
            get { return sitedesc; }
            set { sitedesc = value; }
        }
  
        public float Area
        {
            get { return area; }
            set { area = value; }
        }
  
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
  
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
  
        public int Idcity
        {
            get { return idcity; }
            set { idcity = value; }
        }
  
        public int Idsite
        {
            get { return idsite; }
            set { idsite = value; }
        }
 
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
  
    }
}
