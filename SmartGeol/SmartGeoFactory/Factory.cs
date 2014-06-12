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
            if (obj is sitenaturelcs)
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

            // Execution de la commande
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
        internal void Modifier(object obj)
        {

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
