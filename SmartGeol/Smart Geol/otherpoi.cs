using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_Geol
{
    class otherpoi
    {
        private int id;
        private int bookingid;
        private int idcity;
        private string bookingdesc;
        private int datetrip;
        private int duration;
        private string paymentmode;
        private int bookingdate;
        private int userid;
        private int courtierid;
        private int pointofinterestid;
        private int idsite;

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
        
        public int Courtierid
        {
            get { return courtierid; }
            set { courtierid = value; }
        }
       
        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        
        public int Bookingdate
        {
            get { return bookingdate; }
            set { bookingdate = value; }
        }
        
        public string Paymentmode
        {
            get { return paymentmode; }
            set { paymentmode = value; }
        }
        
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        
        public int Datetrip
        {
            get { return datetrip; }
            set { datetrip = value; }
        }
        
        public string Bookingdesc
        {
            get { return bookingdesc; }
            set { bookingdesc = value; }
        }
       
        public int Idcity
        {
            get { return idcity; }
            set { idcity = value; }
        }
        
        public int Bookingid
        {
            get { return bookingid; }
            set { bookingid = value; }
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
    }
}
