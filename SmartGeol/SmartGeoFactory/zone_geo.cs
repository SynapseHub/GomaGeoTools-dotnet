using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text;

namespace SmartGeoFactory
{
   public  class zone_geo
    {
        private int id;
        private int zoneGeoId;
        private float areazone;
        private float lngzone;
        private float latzone;
        private string etenduZoneGeo;
        private string descZoneGeo;
        private string nameZoneGeo;
public int Id
        {
            get {
                if (id != null) 
                {
                    return id;
                }
                else
                    throw new Exception("L'ID est vide");

                 }
            set { id = value; }
        }
        public int ZoneGeoId
        {
            get { return zoneGeoId; }
            set {
                if (value > 0) 
                {
                    zoneGeoId = value;
                }
                else
                    throw new Exception("L'Identifiant est inferieur a Zero");
                 }
        }
        

        public string NameZoneGeo
        {
            get {
                if (nameZoneGeo != null) {

                    return nameZoneGeo;
                }
                else
                    throw new Exception("Le nom de la Zone est vide");                 
            }
            set
            {
                if (value.Length <= 100)
                {
                    nameZoneGeo = value;
                }
                else
                    throw new Exception("Le nom de la Zone est trop long");
            }
        }
        

        public string DescZoneGeo
        {
            get
            {
                if (descZoneGeo != null){
                    return descZoneGeo;
                }
                else
                    throw new Exception("La description de la Zone est vide");
            }
            set {
                if (value.Length <= 0) {
                    throw new Exception("La description de la Zone est vide");
                }
                descZoneGeo = value; }
        }
        

        public string EtenduZoneGeo
        {
            get { 
                if (EtenduZoneGeo!=null)
                {
                    return  etenduZoneGeo;
                }
                else
                    throw new Exception("L'étendue de la zone Géographique est vide");
            }
            set { etenduZoneGeo = value; }
        }
        

        public float Latzone
        {
            get {
                if (Latzone!=null){
                return latzone;
                }
                 }
            else

            throw new Exception("L'étendue de la zone Géographique est vide");
            
            set { latzone = value; }
        }
        

        public float Lngzone
        {
            get { return lngzone; }
            set { lngzone = value; }
        }
        

        public float Areazone
        {
            get { return areazone; }
            set { areazone = value; }
        }
        
  
      }
}
