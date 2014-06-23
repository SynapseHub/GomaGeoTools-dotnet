using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartGeoFactory
{
   public class image
    {
        private int id;
        private int pointofinterestid;
        private string name;
        private string url;
//création d'une variable pour stocker les images
        private BitConverter image;
        private string imagetype;

        public string Imagetype
        {
            get { return imagetype; }
            set { imagetype = value; }
        }
        public BitConverter Image
        {
            get { return image; }
            set { image = value; }
        }
    
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    
        public int Pointofinterestid
        {
            get { return pointofinterestid; }
            set { pointofinterestid = value; }
        }
    
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    
    }
}
