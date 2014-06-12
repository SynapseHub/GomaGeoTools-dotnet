using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SmartGeoFactory
{
    public class Factory
    {
        private SqlConnection connect;

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

        ///<summary>
        /// Cette fonction permet d'initialiser notre connexion a la base des donnees
        /// </summary>
        /// <param name="connectionLink"></param>
        public void Initialise(string connectionLink)
        {
            connect = new SqlConnection(connectionLink);
        }
        




// The End of the Class
    }
}
