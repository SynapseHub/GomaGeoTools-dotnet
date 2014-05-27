using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Geol
{
    class restaurant
    {
        private int id;
        private int pointofinterestid;
        private int idcity;
        private string title;
        private string type;
        private string url;
        private string classification;
        private float latitude;
        private float longitude;
        private string description;
        private string mealofday;
        private string mealprice;
        private string pictureurl;

        public int Id
        {
            get {return id; }
            set {
                //la verification de la valeur de l'ID
                if (value >0) 
                {
                    id = value;          
              } 
                else
                    throw new Exception("L'ID est inferieur a Zero");
                // id = value;
            }
        }
       

        public int Pointofinterestid
        {
            get { return pointofinterestid; }
            set {
                //la verification de la valeur de pointofinterestid
                if (value > 0)
                {
                    pointofinterestid = value; ;
                }
                else
                    throw new Exception("Le pointofinterestid est inferieur a Zero");
                //pointofinterestid = value; 
            }
        }
  

  public int Idcity
  {
      get { return idcity; }
      set {
          if (value > 0)
          {
              idcity = value;
          }
          else
              throw new Exception("L'id de la Cite est inferieur a Zero");
           }
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
  

  public string Url
  {
      get { return url; }
      set { url = value; }
  }
  

  public string Classification
  {
      get { return classification; }
      set { classification = value; }
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
  

  public string Description
  {
      get { return description; }
      set { description = value; }
  }
  

  public string Mealofday
  {
      get { return mealofday; }
      set { mealofday = value; }
  }
  
  public string Mealprice
  {
      get { return mealprice; }
      set { mealprice = value; }
  }
  

  public string Pictureurl
  {
      get { return pictureurl; }
      set { pictureurl = value; }
  }

    }
}
