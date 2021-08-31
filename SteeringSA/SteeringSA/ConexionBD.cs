using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SteeringSA
{
    public class ConexionBD
    {
        private SqlConnection _mySqlConnection;

        public SqlConnection SQLConnection { get { return _mySqlConnection; } }

        private static ConexionBD _instance;

        public static ConexionBD Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConexionBD();
                }

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public void InicializarConxion()
        {
            string myStringConnection = ConfigurationManager.ConnectionStrings["SteeringSA.Properties.Settings.Steering_S_AConnectionString"].ConnectionString;

            _mySqlConnection = new SqlConnection(myStringConnection);
        }
    }
}
