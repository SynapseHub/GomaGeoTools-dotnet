using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Geol
{
    class datatype
    {
        private int id;
        private int dataid;
        private string titletype;

        public string Titletype
        {
            get { return titletype; }
            set { titletype = value; }
        }
        public int Dataid
        {
            get { return dataid; }
            set { dataid = value; }
        }
  
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
  
      }
}
