using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace SmartGeoFactory
{
    public class Factory
    {
        private SqlConnection connect;
        private IDbConnection allcon;
        public MySqlConnection mysqlCon;

        public IDbConnection allCon
        {
            get { return allcon; }
            set { allcon = value; }
        }

        // pour tester, si Ok on va use celui-ci
        String mysqlConStr = "Server=localhost;Port=8080;Database=smartgeotools;Uid=Admin;password=Test;";
        String genStrConn = "";


        private Factory()
        {
            //NUll constructor ceci pour empecher de faire new Factory ....
        }

        //Creation d'une instance 
        private static Factory _fact;
        public static Factory Instance
        {
            get
            {
                if (_fact == null) _fact = new Factory();
                return _fact;
            }
        }

        #region Ouverture et Fermeture de la connexion 
        
        /// <summary>
        /// Permet l'ouverture de la connection à la base de données pour afficher le report
        /// et retourne un objet représentant la connexion à la dite base de données
        /// </summary>
        /// <returns>Objet IDbConnection</returns>
        public MySqlConnection iConnect()
        {
            mysqlCon = new MySqlConnection(mysqlConStr);
            mysqlCon.Open();
            if (mysqlCon.State.ToString().Equals("")) throw new Exception("Connexion to the database failed !!!");
            else if (mysqlCon.State.ToString().Equals("Open")) { }
            else mysqlCon.Open();

            return mysqlCon;
        }
        /// <summary>
        /// Permet la fermeture de la connexion à la base de données
        /// </summary>
        public void closeMyConnection()
        {
            connect = null;
        }

        #endregion

        #region Verification et execution de la connexion a la BD

        public bool CheckToConnect(int? port, string server, string database, string Uid, string pwd, int valueDb)
        {
            bool ok = false;
            genStrConn = "Server=" + server + ";Database=" + database + ";Uid=" + Uid + ";Pwd=" + pwd;
            allcon = new MySqlConnection(genStrConn);
            allcon.Open();
            
            ok = true;

            return ok;
        }

        #endregion

        ///<summary>
        /// Cette fonction permet d'initialiser notre connexion a la base des donnees
        /// </summary>
        /// <param name="connectionLink"></param>
        public void Initialise(string connectionLink)
        {
            connect = new SqlConnection(connectionLink); //a supprimer au cas ou celui de MySql marche a merveille
            //Initialise also with MySql
            mysqlCon = new MySqlConnection(mysqlConStr);
        }


        /**
         *  Utilisation 
         * MySqlCommand msqlcmd=mysqlCon.CreateCommand();
         * msqlcmd.CommandText="Select * from sitenaturel where id=2";
         * try
         * {
         *      msqlcmd.Open();
         * } catch(Exception ex){
         *      Console.WriteLine(ex.Message);
         * }
         * MySqlDataReader reader=msqlcmd.ExecuteReader();
         * while(reader.Read())
         * {
         *       Console.WriteLine(reader["text"].ToString());
         * }
         * Console.ReadLine();
         * *** pour inserer 
         * msqlcmd.CommandText="insert into tablename(id,name) values (1,'michel')";
         * mysqlCon.Open();
         * msqlcmd.ExecuteNonQuery();
         * //when you finish
         * mysqlCon.Close();
         * 
         */

        #region Enregistrement des donnees quelque soit la classe

        /// <summary>
        /// Permet d'enregistrer des donnees dans la base de données quelque soit le type d'objet
        /// </summary>
        /// <param name="obj">Object</param>
        internal void Save(object obj)
        {
            if (allcon.State.ToString().Equals("Open")) { }
            else allcon.Open();

            IDbCommand cmdSave = null, cmdSavex = null;
            bool okSave = false;
            //Objet City
            if (obj is City)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into city(idcity,idzone,namecity,desccity,latcity,lngcity,altcity,cityurlimage) 
                values(@idcity,@idzone,@namecity,@desccity,@latcity,@lngcity,@altcity,@cityurlimage)";
                IDataParameter paramIdcity = cmdSave.CreateParameter();
                paramIdcity.ParameterName = "@idcity";
                paramIdcity.Value = ((City)obj).Idcity;
                IDataParameter paramIdzone = cmdSave.CreateParameter();
                paramIdzone.ParameterName = "@idzone";
                paramIdzone.Value = ((City)obj).Idzone;
                IDataParameter paramName = cmdSave.CreateParameter();
                paramName.ParameterName = "@namecity";
                paramName.Value = ((City)obj).Namecity;
                IDataParameter paramDescCity = cmdSave.CreateParameter();
                paramDescCity.ParameterName = "@desccity";
                paramDescCity.Value = ((City)obj).Desccity;
                IDataParameter paramLatCity = cmdSave.CreateParameter();
                paramLatCity.ParameterName = "@latcity";
                paramLatCity.Value = ((City)obj).Latcity;
                IDataParameter paramLngCity = cmdSave.CreateParameter();
                paramLngCity.ParameterName = "@lngcity";
                paramLngCity.Value = ((City)obj).Lngcity;
                IDataParameter paramCityUrlImage = cmdSave.CreateParameter();
                paramCityUrlImage.ParameterName = "@cityurlimage";
                paramCityUrlImage.Value = ((City)obj).Cityurlimage;
                // il faut ajouter tout les attributs de la classe City
                cmdSave.Parameters.Add(paramIdcity);
                cmdSave.Parameters.Add(paramIdzone);
                cmdSave.Parameters.Add(paramName);
                cmdSave.Parameters.Add(paramDescCity);
                cmdSave.Parameters.Add(paramLatCity);
                cmdSave.Parameters.Add(paramLngCity);
                cmdSave.Parameters.Add(paramCityUrlImage);
            }
             else if (obj is sitenaturelcs )
            {
				cmdSave=allcon.CreateCommand();
                cmdSave.CommandText = @"insert into sitenaturel(idsite,idcity,title,type,area,sitedesc,latitude,longitude,attractourist,
        largeur,longueur,security,visitorperan,site_url_image) values (@idsite,@idcity,@title,@type,@area,@sitedesc,@latitude,@longitude,@attractourist,
        @largeur,@longueur,@security,@visitorperan,@site_url_image)";
                IDataParameter paramIdSite = cmdSave.CreateParameter();
                paramIdSite.ParameterName = "@idsite";
                paramIdSite.Value = ((sitenaturelcs)obj).Idsite;
                IDataParameter paramIdCity = cmdSave.CreateParameter();
                paramIdCity.ParameterName = "@idcity";
                paramIdCity.Value = ((sitenaturelcs)obj).Idcity;
                IDataParameter paramTitle = cmdSave.CreateParameter();
                paramTitle.ParameterName = "@title";
                paramTitle.Value = ((sitenaturelcs)obj).Title;
                IDataParameter paramType = cmdSave.CreateParameter();
                paramType.ParameterName = "@type";
                paramType.Value = ((sitenaturelcs)obj).Type;
                IDataParameter paramArea = cmdSave.CreateParameter();
                paramArea.ParameterName = "@area";
                paramArea.Value = ((sitenaturelcs)obj).Area;
                IDataParameter paramSitedesc = cmdSave.CreateParameter();
                paramSitedesc.ParameterName = "@sitedesc";
                paramSitedesc.Value = ((sitenaturelcs)obj).Sitedesc;
                IDataParameter paramLatitude = cmdSave.CreateParameter();
                paramLatitude.ParameterName = "@latitude";
                paramLatitude.Value = ((sitenaturelcs)obj).Latitude;
                IDataParameter paramLongitude = cmdSave.CreateParameter();
                paramLongitude.ParameterName = "@longitude";
                paramLongitude.Value = ((sitenaturelcs)obj).Longitude;
                IDataParameter paramAttract = cmdSave.CreateParameter();
                paramAttract.ParameterName = "@attractourist";
                paramAttract.Value = ((sitenaturelcs)obj).Attractourist;
                IDataParameter paramLargeur = cmdSave.CreateParameter();
                paramLargeur.ParameterName = "@largeur";
                paramLargeur.Value = ((sitenaturelcs)obj).Largeur;
                IDataParameter paramLongueur = cmdSave.CreateParameter();
                paramLongueur.ParameterName = "@longueur";
                paramLongueur.Value = ((sitenaturelcs)obj).Longueur;
                IDataParameter paramSecurity = cmdSave.CreateParameter();
                paramSecurity.ParameterName = "@security";
                paramSecurity.Value = ((sitenaturelcs)obj).Security;
                IDataParameter paramVisitorperan = cmdSave.CreateParameter();
                paramVisitorperan.ParameterName = "@visitorperan";
                paramVisitorperan.Value = ((sitenaturelcs)obj).Visitorperan;
                IDataParameter paramsiteurl = cmdSave.CreateParameter();
                paramsiteurl.ParameterName = "@site_url_image";
                paramsiteurl.Value = ((sitenaturelcs)obj).Site_url_image;

                // il faut ajouter tout les attributs de la classe City
                cmdSave.Parameters.Add(paramIdSite);
                cmdSave.Parameters.Add(paramIdCity);
                cmdSave.Parameters.Add(paramTitle);
                cmdSave.Parameters.Add(paramType);
                cmdSave.Parameters.Add(paramArea);
                cmdSave.Parameters.Add(paramSitedesc);
                cmdSave.Parameters.Add(paramLatitude);
                cmdSave.Parameters.Add(paramLongitude);
                cmdSave.Parameters.Add(paramAttract);
                cmdSave.Parameters.Add(paramLargeur);
                cmdSave.Parameters.Add(paramLongueur);
                cmdSave.Parameters.Add(paramSecurity);
                cmdSave.Parameters.Add(paramVisitorperan);
                cmdSave.Parameters.Add(paramsiteurl);
				
			}
            else if (obj is booking )

            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into booking(bookingid,idcity,bookingdesc,datetrip,duration,paymentmode,bookingdate,userid,courtierid,
        pointofinterestid,idsite) values (@bookingid,@idcity,@bookingdes,@datetrip,@duration,@paymentmode,@bookingdate,@userid,@courtierid,
        @pointofinterestid,@idsite)";
                IDataParameter paramBookingid = cmdSave.CreateParameter();
                paramBookingid.ParameterName = "@bookingid";
                paramBookingid.Value = ((booking )obj).Bookingid;
                IDataParameter paramIdcity = cmdSave.CreateParameter();
                paramIdcity.ParameterName = "@idcity";
                paramBookingid.Value = ((booking)obj).Idcity;
                IDataParameter paramBookingdesc = cmdSave.CreateParameter();
                paramBookingdesc.ParameterName = "@bookingdesc";
                paramBookingdesc.Value = ((booking)obj).Bookingdesc;
                IDataParameter paramDatetrip = cmdSave.CreateParameter();
                paramDatetrip.ParameterName = "@datetrip";
                paramDatetrip.Value = ((booking)obj).Datetrip;
                IDataParameter paramDuration = cmdSave.CreateParameter();
                paramDuration.ParameterName = "@duration";
                paramDuration.Value = ((booking)obj).Duration;
                IDataParameter paramPaymentmode = cmdSave.CreateParameter();
                paramPaymentmode.ParameterName = "@paymentmode";
                paramPaymentmode.Value = ((booking)obj).Paymentmode;
                IDataParameter paramBookingdate = cmdSave.CreateParameter();
                paramBookingdate.ParameterName = "@bookingdate";
                paramBookingdate.Value = ((booking)obj).Bookingdate;
                IDataParameter paramUserid = cmdSave.CreateParameter();
                paramUserid.ParameterName = "@userid";
                paramUserid.Value = ((booking)obj).Userid;
                IDataParameter paramCourtierid = cmdSave.CreateParameter();
                paramCourtierid.ParameterName = "@courtierid";
                paramCourtierid.Value = ((booking)obj).Courtierid;

                //ajoutter les methodes de la classe booking
                cmdSave.Parameters.Add(paramBookingid);
                cmdSave.Parameters.Add(paramIdcity);
                cmdSave.Parameters.Add(paramBookingdesc);
                cmdSave.Parameters.Add(paramDatetrip);
                cmdSave.Parameters.Add(paramDuration);
                cmdSave.Parameters.Add(paramPaymentmode);
                cmdSave.Parameters.Add(paramBookingdate);
                cmdSave.Parameters.Add(paramUserid);
                cmdSave.Parameters.Add(paramCourtierid);
              }
            else if (obj is comments)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into comments(userid,pointofinterestid,idsite,text,date) values (@userid,@pointofinterstid,@idsite,text,date)";
                IDataParameter paramUserid = cmdSave.CreateParameter();
                paramUserid.ParameterName = "@userid";
                paramUserid.Value = ((comments)obj).Userid;
                IDataParameter paramPointofinterestid = cmdSave.CreateParameter();
                paramPointofinterestid.ParameterName = "@pointofinterestid";
                paramPointofinterestid.Value = ((comments)obj).Pointofinterestid;
                IDataParameter paramIdsite = cmdSave.CreateParameter();
                paramIdsite.ParameterName = "@idsite";
                paramIdsite.Value = ((comments)obj).Idsite;
                IDataParameter paramText = cmdSave.CreateParameter();
                paramText.ParameterName = "@text";
                paramText.Value = ((comments)obj).Text ;
                IDataParameter paramDate = cmdSave.CreateParameter();
                paramDate.ParameterName = "@date";
                paramDate.Value = ((comments)obj).Date;

                //mettre les atribut de la classe comments

                cmdSave.Parameters.Add(paramUserid);
                cmdSave.Parameters.Add(paramPointofinterestid);
                cmdSave.Parameters.Add(paramIdsite);
                cmdSave.Parameters.Add(paramText);
                cmdSave.Parameters.Add(paramDate);
                
             }
            else if (obj is courtier)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into courtier(courtierid,email,password,title,lastname,firstname,website,city,country,company,phone,biography,specification) values (@courtierid,@email,@password,@title,@lastname,@firstname,@website,@city,@country,@company,@phone,@biography,@specification)";
                IDataParameter paramCourtierid = cmdSave.CreateParameter();
                paramCourtierid.ParameterName = "@courtierid";
                paramCourtierid.Value = ((courtier )obj).Courtierid;
                IDataParameter paramEmail = cmdSave.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = ((courtier)obj).Email;
                IDataParameter paramPassword = cmdSave.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = ((courtier)obj).Password;
                IDataParameter paramTitle = cmdSave.CreateParameter();
                paramTitle.ParameterName = "@title";
                paramTitle.Value = ((courtier)obj).Title;
                IDataParameter paramLastname = cmdSave.CreateParameter();
                paramLastname.ParameterName = "@lastname";
                paramLastname.Value = ((courtier )obj).Lastname;
                IDataParameter paramFirstname = cmdSave.CreateParameter();
                paramFirstname.ParameterName = "@firstname";
                paramFirstname.Value = ((courtier )obj).Firstname;
                IDataParameter paramWebsite = cmdSave.CreateParameter();
                paramWebsite.ParameterName = "@website";
                paramWebsite.Value = ((courtier )obj).Website;
                IDataParameter paramCity = cmdSave.CreateParameter();
                paramCity.ParameterName = "@city";
                paramCity.Value = ((courtier )obj).City;
                IDataParameter paramCountry = cmdSave.CreateParameter();
                paramCountry.ParameterName = "@country";
                paramCountry.Value = ((courtier )obj).Country;
                IDataParameter paramCompany = cmdSave.CreateParameter();
                paramCompany.ParameterName = "@company";
                paramCompany.Value = ((courtier )obj).Courtierid;
                IDataParameter paramPhone = cmdSave.CreateParameter();
                paramPhone.ParameterName = "@phone";
                paramPhone.Value = ((courtier )obj).Phone;
                IDataParameter paramBiography = cmdSave.CreateParameter();
                paramBiography.ParameterName = "@biography";
                paramBiography.Value = ((courtier )obj).Biography;
                IDataParameter paramSpecification = cmdSave.CreateParameter();
                paramSpecification.ParameterName = "@specification";
                paramSpecification.Value = ((courtier )obj).Specification;

                //ajout de toute les methode de la classe courtier

                cmdSave.Parameters.Add(paramSpecification);
                cmdSave.Parameters.Add(paramBiography);
                cmdSave.Parameters.Add(paramPhone);
                cmdSave.Parameters.Add(paramCompany);
                cmdSave.Parameters.Add(paramCountry);
                cmdSave.Parameters.Add(paramCity);
                cmdSave.Parameters.Add(paramFirstname);
                cmdSave.Parameters.Add(paramWebsite);
                cmdSave.Parameters.Add(paramLastname);
                cmdSave.Parameters.Add(paramTitle);
                cmdSave.Parameters.Add(paramPassword);
                cmdSave.Parameters.Add(paramEmail);
                cmdSave.Parameters.Add(paramCourtierid);
                
                
           }
            else if (obj is datatype)
            {
 cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into datatype(dataid,titletype) values (@dataid,titletype)";
                IDataParameter paramDataid = cmdSave.CreateParameter();
                paramDataid.ParameterName = "@dataid";
                paramDataid.Value = ((datatype  )obj).Dataid;
                IDataParameter paramTitletype = cmdSave.CreateParameter();
                paramTitletype.ParameterName = "@titletype";
                paramTitletype.Value = ((datatype  )obj).Titletype;

                //ajout de toute les methodes de la classe datatype

               cmdSave.Parameters.Add (paramDataid);
               cmdSave.Parameters.Add(paramTitletype);

            }
            else if (obj is hotel)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into hotel(idcity,title,type,url,longitude,latitude,adresse,deschotel,star,nbroom,nbroomdispo,roompricemin,roompricemax,mail,pictureurl) values (@idcity,@title,@type,@url,@longitude,@latitude,@adresse,@deschotel,@star,@nbroom,@nbroomdispo,@roompricemin,@roompricemax,@mail,@pictureurl)";
                IDataParameter paramIdcity = cmdSave.CreateParameter();
                paramIdcity.ParameterName = "@idcity";
                paramIdcity.Value = ((hotel)obj).Idcity;
                IDataParameter paramTitle = cmdSave.CreateParameter();
                paramTitle.ParameterName = "@title";
                paramTitle.Value = ((hotel)obj).Title;
                IDataParameter paramType = cmdSave.CreateParameter();
                paramType.ParameterName = "@type";
                paramType.Value = ((hotel)obj).Idcity;
                IDataParameter paramUrl = cmdSave.CreateParameter();
                paramUrl.ParameterName = "@url";
                paramUrl.Value = ((hotel)obj).Url;
                IDataParameter paramLongitude = cmdSave.CreateParameter();
                paramLongitude.ParameterName = "@longitude";
                paramLongitude.Value = ((hotel)obj).Longitude;
                IDataParameter paramLatitude = cmdSave.CreateParameter();
                paramLatitude.ParameterName = "@latitude";
                paramLatitude.Value = ((hotel)obj).Latitude;
                IDataParameter paramAdresse = cmdSave.CreateParameter();
                paramAdresse.ParameterName = "@adresse";
                paramAdresse.Value = ((hotel)obj).Adresse;
                IDataParameter paramDeschotel = cmdSave.CreateParameter();
                paramDeschotel.ParameterName = "@deschotel";
                paramDeschotel.Value = ((hotel)obj).Deschotel;
                IDataParameter paramStar = cmdSave.CreateParameter();
                paramStar.ParameterName = "@star";
                paramDeschotel.Value = ((hotel)obj).Deschotel;
                IDataParameter paramNbroom = cmdSave.CreateParameter();
                paramNbroom.ParameterName = "@nbroom";
                paramNbroom.Value = ((hotel)obj).Nbroom;
                IDataParameter paramNbroomdispo = cmdSave.CreateParameter();
                paramNbroomdispo.ParameterName = "@nbroomdispo";
                paramNbroomdispo.Value = ((hotel)obj).Nbroomdispo;
                IDataParameter paramRoompricemin = cmdSave.CreateParameter();
                paramRoompricemin.ParameterName = "@idcity";
                paramRoompricemin.Value = ((hotel)obj).Roompricemin;
                IDataParameter paramRoompricemax = cmdSave.CreateParameter();
                paramRoompricemax.ParameterName = "@roompricemax";
                paramRoompricemax.Value = ((hotel)obj).Roompricemax;
                IDataParameter paramMail = cmdSave.CreateParameter();
                paramMail.ParameterName = "@mail";
                paramMail.Value = ((hotel)obj).Mail;
                IDataParameter paramPictureurl = cmdSave.CreateParameter();
                paramPictureurl.ParameterName = "@pictureurl";
                paramPictureurl.Value = ((hotel)obj).Idcity;

                //ajout de tout les objet de la classe hotel

                cmdSave.Parameters.Add(paramPictureurl);
                cmdSave.Parameters.Add(paramMail);
                cmdSave.Parameters.Add(paramRoompricemin);
                cmdSave.Parameters.Add(paramRoompricemax);
                cmdSave.Parameters.Add(paramNbroomdispo);
                cmdSave.Parameters.Add(paramNbroom);
                cmdSave.Parameters.Add(paramStar);
                cmdSave.Parameters.Add(paramDeschotel);
                cmdSave.Parameters.Add(paramAdresse);
                cmdSave.Parameters.Add(paramTitle);
                cmdSave.Parameters.Add(paramLatitude);
                cmdSave.Parameters.Add(paramLongitude);
                cmdSave.Parameters.Add(paramUrl);
                cmdSave.Parameters.Add(paramType);
                cmdSave.Parameters.Add(paramTitle);
                cmdSave.Parameters.Add(paramIdcity); 

            }
            else if (obj is image )
            {
             cmdSave = allcon.CreateCommand();
             cmdSave.CommandText = @"insert into image(pointofinterestid,name,url,image,imagetype,) values (@pointofinterestid,@name,@url,@image,@imagetype,)";
                IDataParameter paramPointofinterestid = cmdSave.CreateParameter();
                paramPointofinterestid.ParameterName = "@pointofinterestid";
                paramPointofinterestid.Value = ((image  )obj).Pointofinterestid;
                IDataParameter paramName = cmdSave.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = ((image)obj).Name;
                IDataParameter paramUrl = cmdSave.CreateParameter();
                paramUrl.ParameterName = "@url";
                paramUrl.Value = ((image)obj).Url;
                IDataParameter paramImage = cmdSave.CreateParameter();
                paramImage.ParameterName = "@image";
                paramImage.Value = ((image)obj).Image;
                IDataParameter paramImagetype= cmdSave.CreateParameter();
                paramImagetype.ParameterName = "@imagetype";
                paramImagetype.Value = ((image)obj).Imagetype;

                //ajout de touts les objets de la classe image

                cmdSave.Parameters.Add(paramPointofinterestid);
                cmdSave.Parameters.Add(paramName);
                cmdSave.Parameters.Add(paramUrl);
                cmdSave.Parameters.Add(paramImage);
                cmdSave.Parameters.Add(paramImagetype);
            }
            else if (obj is otherpoi)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into otherpoi(bookingid,idcity,bookingdesc,datetrip,duration,paymentmode,bookingdate,userid,courtierid,pointofinterestid,idsite) values (@bookingid,@idcity,@bookingdesc,@datetrip,@duration,@paymentmode,@bookingdate,@userid,@courtierid,@pointofinterestid,@idsite)";
                IDataParameter paramBookingid = cmdSave.CreateParameter();          
                paramBookingid.ParameterName = "@bookingid";
                paramBookingid.Value = ((otherpoi)obj).Bookingid;
                IDataParameter paramIdcity = cmdSave.CreateParameter();
                paramIdcity.ParameterName = "@idcity";
                paramIdcity.Value = ((otherpoi)obj).Idcity;
                IDataParameter paramBookingdesc = cmdSave.CreateParameter();
                paramBookingdesc.ParameterName = "@bookingdesc";
                paramBookingdesc.Value = ((otherpoi)obj).Bookingdesc;
                IDataParameter paramDatetrip = cmdSave.CreateParameter();
                paramDatetrip.ParameterName = "@datetrip";
                paramDatetrip.Value = ((otherpoi)obj).Datetrip;
                IDataParameter paramDuration = cmdSave.CreateParameter();
                paramDuration.ParameterName = "@duration";
                paramDuration.Value = ((otherpoi)obj).Duration;
                IDataParameter paramPaymentmode = cmdSave.CreateParameter();
                paramPaymentmode.ParameterName = "@paymentmode";
                paramPaymentmode.Value = ((otherpoi)obj).Paymentmode;
                IDataParameter paramBookingdate = cmdSave.CreateParameter();
                paramBookingdate.ParameterName = "@bookingdate";
                paramBookingdate.Value = ((otherpoi)obj).Bookingdate;
                IDataParameter paramUserid = cmdSave.CreateParameter();
                paramUserid.ParameterName = "@userid";
                paramUserid.Value = ((otherpoi)obj).Userid;
                IDataParameter paramCourtierid= cmdSave.CreateParameter();
                paramCourtierid.ParameterName = "@courtierid";
                paramCourtierid.Value = ((otherpoi)obj).Courtierid;
                IDataParameter paramPointofinterestid = cmdSave.CreateParameter();
                paramPointofinterestid.ParameterName = "@pointofinterestid";
                paramPointofinterestid.Value = ((otherpoi)obj).Pointofinterestid;
                IDataParameter paramIdsite = cmdSave.CreateParameter();
                paramIdsite.ParameterName = "@idsite";
                paramIdsite.Value = ((otherpoi)obj).Idsite;

                //ajout de methode de la classe otherpoi
                cmdSave.Parameters.Add(paramBookingid);
                cmdSave.Parameters.Add(paramIdcity);
                cmdSave.Parameters.Add(paramBookingdesc);
                cmdSave.Parameters.Add(paramDatetrip);
                cmdSave.Parameters.Add(paramDuration);
                cmdSave.Parameters.Add(paramPaymentmode);
                cmdSave.Parameters.Add(paramBookingdate);
                cmdSave.Parameters.Add(paramUserid);
                cmdSave.Parameters.Add(paramCourtierid);
                cmdSave.Parameters.Add(paramPointofinterestid);
                cmdSave.Parameters.Add(paramIdsite);

            }
            else if (obj is rating )
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into rating(userid,pointofinterestid,idsite,rating,date) values (@userid,@pointofinterestid,@idsite,@rating,@date)";
                IDataParameter paramUserid = cmdSave.CreateParameter();
                paramUserid.ParameterName = "@userid";
                paramUserid.Value = ((rating)obj).Userid;
                IDataParameter paramPointofinterestid = cmdSave.CreateParameter();
                paramPointofinterestid.ParameterName = "@pointofinterestid";
                paramPointofinterestid.Value = ((rating)obj).Pointofinterestid;
                IDataParameter paramIdsite = cmdSave.CreateParameter();
                paramIdsite.ParameterName = "@idsite";
                paramIdsite.Value = ((rating)obj).Idsite;
                IDataParameter paramRating = cmdSave.CreateParameter();
                paramRating.ParameterName = "@rating";
                paramRating.Value = ((rating)obj).Rating;
                IDataParameter paramDate = cmdSave.CreateParameter();
                paramDate.ParameterName = "@date";
                paramDate.Value = ((rating)obj).Date;

                //ajout de methode de la classe rating

             cmdSave.Parameters.Add(paramUserid);
             cmdSave.Parameters.Add(paramPointofinterestid);
             cmdSave.Parameters.Add(paramIdsite);
             cmdSave.Parameters.Add(paramRating);
             cmdSave.Parameters.Add(paramDate);
           
            
            }



            else if (obj is restaurant)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into restaurant(pointofinterstid,idcity,title,type,classification,latitude,longitude,description,mealofday,mealprice,pictureurl) values (@pointofinterstid,@idcity,@title,@type,@classification,@latitude,@longitude,@description,@mealofday,@mealprice,@pictureurl)";
                IDataParameter paramPointofinterestid = cmdSave.CreateParameter();
                paramPointofinterestid.ParameterName = "@pointofinterstid";
                paramPointofinterestid.Value = ((restaurant)obj).Pointofinterestid;
                IDataParameter paramIdcity = cmdSave.CreateParameter();
                paramIdcity.ParameterName = "@idcity";
                paramIdcity.Value = ((restaurant)obj).Idcity;
                IDataParameter paramTitle = cmdSave.CreateParameter();
                paramTitle.ParameterName = "@title";
                paramTitle.Value = ((restaurant)obj).Title;
                IDataParameter paramType = cmdSave.CreateParameter();
                paramType.ParameterName = "@type";
                paramType.Value = ((restaurant)obj).Type;
                IDataParameter paramClassification = cmdSave.CreateParameter();
                paramClassification.ParameterName = "@classification";
                paramClassification.Value = ((restaurant)obj).Classification;
                IDataParameter paramLatitude = cmdSave.CreateParameter();
                paramLatitude.ParameterName = "@latitude";
                paramLatitude.Value = ((restaurant)obj).Latitude;
                IDataParameter paramLongitude = cmdSave.CreateParameter();
                paramLongitude.ParameterName = @"longitude";
                paramLongitude.Value = ((restaurant)obj).Longitude;
                IDataParameter paramDescription = cmdSave.CreateParameter();
                paramDescription.ParameterName = @"description";
                paramDescription.Value = ((restaurant)obj).Description;
                IDataParameter paramMealofday = cmdSave.CreateParameter();
                paramMealofday.ParameterName = @"mealofday";
                paramMealofday.Value = ((restaurant)obj).Mealofday;
                IDataParameter paramMealprice = cmdSave.CreateParameter();
                paramMealprice.ParameterName = @"mealofprice";
                paramMealprice.Value = ((restaurant)obj).Mealprice;
                IDataParameter paramPictureurl = cmdSave.CreateParameter();
                paramPictureurl.ParameterName = @"pictureurl";
                paramPictureurl.Value = ((restaurant)obj).Pictureurl;

                //ajout de methode de la classe restaurant


                    cmdSave.Parameters.Add(paramPointofinterestid);
                    cmdSave.Parameters.Add(paramIdcity);    
                    cmdSave.Parameters.Add(paramTitle);
                    cmdSave.Parameters.Add(paramType);
                    cmdSave.Parameters.Add(paramClassification);
                    cmdSave.Parameters.Add(paramLatitude);
                    cmdSave.Parameters.Add(paramLongitude);
                    cmdSave.Parameters.Add(paramDescription);
                    cmdSave.Parameters.Add(paramMealofday);
                    cmdSave.Parameters.Add(paramMealprice);
                    cmdSave.Parameters.Add(paramPictureurl); 
            
            }
            else if(obj is users)
            {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into user(userid,usern,pswd,type_acc,email,title,lastname,firstname,website,city,country,company,phone,biographie) values (@userid,@usern,@pswd,@type_acc,@email,@title,@lastname,@firstname,@website,@city,@country,@company,@phone,@biographie)";
                IDataParameter paramUserid = cmdSave.CreateParameter();
                paramUserid.ParameterName = "@userid";
                paramUserid.Value = ((users)obj).Userid;
                IDataParameter paramUsern = cmdSave.CreateParameter();
                paramUsern.ParameterName = "@usern";
                paramUsern.Value = ((users)obj).Usern;
                IDataParameter paramPswd= cmdSave.CreateParameter();
                paramPswd.ParameterName = "@pswd";
                paramPswd.Value = ((users)obj).Pswd;
                IDataParameter paramType_acc = cmdSave.CreateParameter();
                paramType_acc.ParameterName = "@param_acc";
                paramType_acc.Value = ((users)obj).Type_acc;
                IDataParameter paramEmail = cmdSave.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = ((users)obj).Email;

                IDataParameter paramTitle = cmdSave.CreateParameter();
                paramTitle.ParameterName = "@title";
                paramTitle.Value = ((users)obj).Title;
                IDataParameter paramLastname = cmdSave.CreateParameter();
                paramLastname.ParameterName = "@lastname";
                paramLastname.Value = ((users )obj).Lastname;
                IDataParameter paramFirstname = cmdSave.CreateParameter();
                paramFirstname.ParameterName = "@firstname";
                paramFirstname.Value = ((users )obj).Firstname;
                IDataParameter paramWebsite = cmdSave.CreateParameter();
                paramWebsite.ParameterName = "@website";
                paramWebsite.Value = ((users )obj).Website;
                IDataParameter paramCity = cmdSave.CreateParameter();
                paramCity.ParameterName = "@city";
                paramCity.Value = ((users )obj).City;
                IDataParameter paramCountry = cmdSave.CreateParameter();
                paramCountry.ParameterName = "@country";
                paramCountry.Value = ((users )obj).Country;
                IDataParameter paramCompany = cmdSave.CreateParameter();
                paramCompany.ParameterName = "@company";
                paramCompany.Value = ((users )obj).Company;
                IDataParameter paramPhone = cmdSave.CreateParameter();
                paramPhone.ParameterName = "@phone";
                paramPhone.Value = ((users )obj).Phone;
                IDataParameter paramBiography = cmdSave.CreateParameter();
                paramBiography.ParameterName = "@biography";
                paramBiography.Value = ((users )obj).Biography;
                //ajout de methodes de la classe users

                 cmdSave.Parameters.Add(paramUserid);
                 cmdSave.Parameters.Add(paramUsern);
                 cmdSave.Parameters.Add(paramPswd);    
                 cmdSave.Parameters.Add(paramType_acc);
                 cmdSave.Parameters.Add(paramEmail);
                 cmdSave.Parameters.Add(paramTitle);
                 cmdSave.Parameters.Add(paramLastname);
                 cmdSave.Parameters.Add(paramBiography);
                 cmdSave.Parameters.Add(paramPhone);
                 cmdSave.Parameters.Add(paramCompany);
                 cmdSave.Parameters.Add(paramCountry);
                 cmdSave.Parameters.Add(paramCity);
                 cmdSave.Parameters.Add(paramFirstname);
                 cmdSave.Parameters.Add(paramWebsite);
            
            
             }

            else if (obj is zone_geo)

          {
                cmdSave = allcon.CreateCommand();
                cmdSave.CommandText = @"insert into zone_geo(zoneGeoId,areazone,lngzone,latzone,etenduZoneGeo,descZoneGeo,nameZoneGeo) values (@zoneGeoid,@areazone,@lngzone,@latzone,@etenduZoneGeo,@descZoneGeo,@nameZoneGeo;)";
                IDataParameter paramZoneGeoId = cmdSave.CreateParameter();
                paramZoneGeoId.ParameterName = "@zoneGeoid";
                paramZoneGeoId.Value = ((zone_geo)obj).ZoneGeoId;
                IDataParameter paramAreazone = cmdSave.CreateParameter();
                paramAreazone.ParameterName = "@areazone";
                paramAreazone.Value = ((zone_geo)obj).Areazone;
                IDataParameter paramLngzone = cmdSave.CreateParameter();
                paramLngzone.ParameterName = "@lngzone";
                paramLngzone.Value = ((zone_geo)obj).Lngzone;
                IDataParameter paramLatzone = cmdSave.CreateParameter();
                paramLatzone.ParameterName = "@latzone";
                paramLatzone.Value = ((zone_geo)obj).Latzone;
                
                IDataParameter paramEtenduZoneGeo = cmdSave.CreateParameter();
                paramEtenduZoneGeo.ParameterName = "@etenduZoneGeo";
                paramEtenduZoneGeo.Value = ((zone_geo)obj).EtenduZoneGeo;
                IDataParameter paramDescZoneGeo = cmdSave.CreateParameter();
                paramDescZoneGeo.ParameterName = "@descZoneGeo";
                paramDescZoneGeo.Value = ((zone_geo)obj).DescZoneGeo;
                IDataParameter paramNameZoneGeo = cmdSave.CreateParameter();
                paramNameZoneGeo.ParameterName = "@nameZoneGeo";
                paramNameZoneGeo.Value = ((zone_geo)obj).NameZoneGeo;



                //ajout des methode de la classe Zone_geo

                cmdSave.Parameters.Add(paramZoneGeoId);
                cmdSave.Parameters.Add(paramAreazone);
                cmdSave.Parameters.Add(paramLngzone);
                cmdSave.Parameters.Add(paramLatzone);
             
                cmdSave.Parameters.Add(paramLatzone);
              
                cmdSave.Parameters.Add(paramEtenduZoneGeo);
                cmdSave.Parameters.Add(paramDescZoneGeo);
                cmdSave.Parameters.Add(paramNameZoneGeo);
                
 }
            //Execution de la commande
            if (!okSave)
            {
                cmdSave.ExecuteNonQuery();
                cmdSave.Dispose();
            }
            allcon.Close();

        }

        #endregion

        #region Modification des donnees quelque soit la classe

        /// <summary>
        /// Permet de modifier des donnees dans la base de données quelque soit le type d'objet
        /// </summary>
        /// <param name="obj">Object</param>
        internal void Updater(object obj)
        {
            if (allcon.State.ToString().Equals("Open")) { }
            else allcon.Open();

           IDbCommand cmdUpdate = null, cmdUpdate1 = null;
            bool ok = false;
            if (obj is City)
            {
               cmdUpdate  = allcon.CreateCommand();
                cmdUpdate.CommandText = "Update city set idcity=@idcity,idzone=@idzone,namecity=@namecity,desccity=@desccity,latcity=@latcity,lngcity=@lngcity,cityurlimage=@cityurlimage where id=@id ";
                IDataParameter paramIdcity = cmdUpdate.CreateParameter();
                paramIdcity.ParameterName = "@id";
                paramIdcity.Value = ((City )obj).Idcity; 
            
                IDataParameter paramIdzone = cmdUpdate.CreateParameter();
                paramIdzone.ParameterName = "@idzone";
                paramIdzone.Value = ((City )obj).Idzone;

                IDataParameter paramNamecity= cmdUpdate.CreateParameter();
                paramNamecity.ParameterName = "@namecity";
                paramNamecity.Value = ((City )obj).Namecity;

                IDataParameter paramDesccity = cmdUpdate.CreateParameter();
                paramDesccity.ParameterName = "@desccity";
                paramDesccity.Value = ((City)obj).Desccity;

                IDataParameter paramLatcity = cmdUpdate.CreateParameter();
                paramLatcity.ParameterName = "@latcity";
                paramLatcity.Value = ((City )obj).Latcity;

                IDataParameter paramLngcity = cmdUpdate.CreateParameter();
                paramLngcity.ParameterName = "@lngcity";
                paramLngcity.Value = ((City )obj).Lngcity;

                IDataParameter paramCityurlimage= cmdUpdate.CreateParameter();
                paramCityurlimage.ParameterName = "@cityurlimage";
                paramCityurlimage.Value = ((City )obj).Cityurlimage;
                //add de methodes de la classe city

                cmdUpdate.Parameters .Add (paramIdcity );
                 cmdUpdate .Parameters .Add (paramIdzone );
                 cmdUpdate.Parameters.Add(paramLatcity);
                 cmdUpdate.Parameters.Add(paramLngcity );
                 cmdUpdate.Parameters.Add(paramDesccity);
                 cmdUpdate.Parameters.Add(paramCityurlimage);
            }

            else if (obj is sitenaturelcs)
            { 
            cmdUpdate= allcon.CreateCommand();
            cmdUpdate.CommandText = "Update sitenaturelcs set id=@id,idsite=@idsite,idcity=@idcity,title=@title,type=@type,area=@area,sitedesc=@sitedesc,latitude=@latitude,longitude=@longitude,attractourist=@attractourist,largeur=@largeur,longueur=@longueur,security=@security,visitorperan=@visitorperan,site_url_image=@site_url_image where id=@id  ";
            IDataParameter paramId=cmdUpdate .CreateParameter ();
            paramId .ParameterName ="@id";
            paramId .Value =((sitenaturelcs )obj).Id;
                
            IDataParameter paramIdsite=cmdUpdate.CreateParameter();
            paramIdsite .ParameterName ="idsite";
            paramIdsite .Value =((sitenaturelcs )obj ).Idsite ;
            IDataParameter paramIdcity=cmdUpdate .CreateParameter ();
            paramIdcity .ParameterName ="@idcity";
            paramIdcity.Value =((sitenaturelcs )obj ).Idcity ;
            IDataParameter paramTitle=cmdUpdate .CreateParameter ();
            paramIdcity .ParameterName ="@title";
            paramTitle .Value =((sitenaturelcs )obj).Title ;
            IDataParameter paramType=cmdUpdate .CreateParameter ();
            paramType .ParameterName ="@type" ;
            paramType .Value =((sitenaturelcs )obj).Type ;
            IDataParameter paramArea=cmdUpdate .CreateParameter ();
            paramArea.ParameterName ="@area";
            paramArea.Value =((sitenaturelcs )obj).Area;
            IDataParameter paramSitedesc=cmdUpdate .CreateParameter ();
            paramSitedesc.ParameterName ="@sitedesc";
            paramSitedesc .Value =((sitenaturelcs )obj ).Sitedesc;
            IDataParameter paramLatitude=cmdUpdate.CreateParameter ();
            paramLatitude.ParameterName ="@latitude" ;
            paramLatitude .Value =((sitenaturelcs )obj).Latitude ;
            IDataParameter  paramLongitude=cmdUpdate .CreateParameter();
            paramLongitude .ParameterName ="@longitude";
            paramLongitude .Value =((sitenaturelcs )obj).Longitude;
            IDataParameter paramAttractourist=cmdUpdate .CreateParameter ();
            paramAttractourist .ParameterName ="@attractourist";
            paramAttractourist .Value =((sitenaturelcs )obj ).;
IDataParameter paramLargeur=cmdUpdate .CreateParameter ();
                paramLargeur .ParameterName ="@largeur";
                paramLargeur .Value =((sitenaturelcs )obj).Largeur;

IDataParameter paramLongueur=cmdUpdate .CreateParameter ();
                paramLongueur .ParameterName ="@longueur";
                paramLongueur .Value =((sitenaturelcs )obj).Longueur;
IDataParameter  parameSecurity=cmdUpdate .CreateParameter ();
                parameSecurity.ParameterName ="@security";
                parameSecurity .Value =((sitenaturelcs )obj).Security ;
               IDataParameter paramVisitorperan=cmdUpdate .CreateParameter ();
                paramVisitorperan.ParameterName ="@visitorperan";
                paramVisitorperan .Value =((sitenaturelcs )obj).Visitorperan ;
IDataParameter paramSite_url_image=cmdUpdate.CreateParameter ();
                paramSite_url_image .ParameterName ="@site_url_image";
                paramSite_url_image .Value =((sitenaturelcs )obj).Site_url_image ;
//ajout de methodes de la classe sitenaturelcs
                cmdUpdate .Parameters .Add(paramId);
                cmdUpdate .Parameters .Add (paramIdsite);
                cmdUpdate .Parameters .Add (paramIdcity );
                cmdUpdate .Parameters .Add (paramTitle );
                cmdUpdate .Parameters .Add (paramType );
                cmdUpdate .Parameters .Add (paramArea );
             cmdUpdate .Parameters.Add (paramSitedesc );
              
                cmdUpdate .Parameters .Add (paramSite_url_image );
                cmdUpdate .Parameters .Add (paramLatitude );
                cmdUpdate .Parameters .Add (paramLongitude );
                cmdUpdate .Parameters .Add (paramAttractourist );
                cmdUpdate .Parameters .Add (paramLargeur );
                cmdUpdate .Parameters .Add (paramLongueur );
                cmdUpdate .Parameters .Add (paramVisitorperan );
               



            }
        
        
        
        
        
        
        
   }





        #endregion
        

        #region Suppression des donnees quelque soit la classe

        /// <summary>
        /// Permet de supprimer des donnees dans la base de données quelque soit le type d'objet
        /// </summary>
        /// <param name="obj">Object</param>
        internal void Supprimer(object obj)
        {

        }
        #endregion

        // The End of the Class
    }
}
