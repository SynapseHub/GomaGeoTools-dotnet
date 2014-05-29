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
                cmdSave.CommandText = @"insert into city(id,cityname)
                    values(@id,@designation)";
                IDataParameter paramId = cmdSave.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = ((City)obj).Idcity;
                IDataParameter paramName = cmdSave.CreateParameter();
                paramName.ParameterName = "@cityname";
                paramName.Value = ((City)obj).Namecity;
                // il faut ajouter tout les attributs de la classe City
                cmdSave.Parameters.Add(paramId);
                cmdSave.Parameters.Add(paramName);
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







        // The End of the Class
    }
}
