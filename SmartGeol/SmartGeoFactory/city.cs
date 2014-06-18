using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartGeoFactory
{
    class City
    {
        private int id;
        private int idcity;
        private int idzone;
        private string namecity;
        private string desccity;
        private float latcity;
        private float lngcity;
        private string cityurlimage;
        private List<City> lstCity; //Methode pour une liste typé sous City

        //Ici on va créer seulement son getter
        public List<City> LstCity
        {
            get
            {
                if (lstCity == null) lstCity = new List<City>();
                return lstCity;
            }
        }


        public override string ToString()
        {
            return this.Namecity.ToString();
        }

        //Accesseurs et Mutateurs
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
        

        public int Idzone
        {
            get { return idzone; }
            set { idzone = value; }
        }
       

        public string Namecity
        {
            get { return namecity; }
            set { namecity = value; }
        }
        

        public string Desccity
        {
            get { return desccity; }
            set { desccity = value; }
        }
        

        public float Latcity
        {
            get { return latcity; }
            set { latcity = value; }
        }
        
        public float Lngcity
        {
            get { return lngcity; }
            set { lngcity = value; }
        }
        

        public string Cityurlimage
        {
            get { return cityurlimage; }
            set { cityurlimage = value; }
        }

        //Methodes publiques et operations sur les objets City
        public void Enregistrer()
        {
            Factory.Instance.Save(this);
        }
        public void Modifier()
        {
            Factory.Instance.Modifier(this);
        }
        public void Supprimer()
        {
            Factory.Instance.Supprimer(this);
        }


    }
}
