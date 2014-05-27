using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Geol
{
    class comments
    {
        private int id;
        private int userid;
        private int pointofinterestid;
        private int idsite;
        private string text;
        private int date;

        public int Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
  
        public int Idsite
        {
            get { return idsite; }
            set { idsite = value; }
        }
  
        public int Pointofinterestid
        {
            get { return pointofinterestid; }
            set { pointofinterestid = value; }
        }
  
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
  
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
  
    }
}
