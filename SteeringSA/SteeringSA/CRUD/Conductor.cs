using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace SteeringSA.CRUD
{
    public class Conductor
    {
        #region VARIABLES PRIVADAS
        private string _cedula;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _fechaNacimiento;
        private string _tipoSangre;
        private string _tipoLicencia;

        private string _msjExito;
        private string _msjError;
        #endregion

        #region PROPIEDADES
        public string Cedula { get { return _cedula; } set { _cedula = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public string TipoSangre { get { return _tipoSangre; } set { _tipoSangre = value; } }
        public string TipoLicencia { get { return _tipoLicencia; } set { _tipoLicencia = value; } }
        #endregion

        #region SINGLETON
        private static Conductor _instance;

        /// <summary>
        /// Patron del singleton
        /// </summary>
        /// <remarks>
        /// Instancia que puede ser llamada desde cualquier clase sin necesidad de crear un objeto.
        /// Tambien evita que se cree mas de una instancia de la clase Conductor.
        /// </remarks>
        public static Conductor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Conductor();
                }

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region METODOS AUXILIARES
        private void MensajesDesdeBD(SqlCommand cmd)
        {
            _msjExito = null;
            _msjError = null;

            _msjExito = cmd.Parameters["@MsjExito"].Value.ToString();
            _msjError = cmd.Parameters["@MsjError"].Value.ToString();

            if (_msjExito != null) MessageBox.Show(_msjExito, "Éxito");
            else if (_msjError != null) MessageBox.Show(_msjError, "Error");
            else MessageBox.Show("Error no identificado", "Error");
        }
        #endregion

        #region CRUD

        /// <summary>
        /// Registra un conductor en la base de datos.
        /// </summary>
        /// <remarks>
        /// Llama al procedimiento almacenado "insertar_conductor" para hacer la operacion de insercion.
        /// </remarks>
        public void Registrar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insertar_conductor", ConexionBD.Instance.SQLConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", Cedula);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@telefono", Telefono);
                cmd.Parameters.AddWithValue("@fechaNac", FechaNacimiento);
                cmd.Parameters.AddWithValue("@tipoSangre", TipoSangre);
                cmd.Parameters.AddWithValue("@tipoLicencia", TipoLicencia);

                cmd.Parameters.Add("@MsjExito", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                ConexionBD.Instance.SQLConnection.Open();
                cmd.ExecuteNonQuery();

                MensajesDesdeBD(cmd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                ConexionBD.Instance.SQLConnection.Close();
            }
        }

        /// <summary>
        /// Actualiza un registro de conductor en la base de datos.
        /// </summary>
        /// <remarks>
        /// Llama al procedimiento almacenado "actualizar_conductor"
        /// </remarks>
        public void Actualizar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("actualizar_conductor", ConexionBD.Instance.SQLConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", Cedula);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@telefono", Telefono);
                cmd.Parameters.AddWithValue("@fechaNac", FechaNacimiento);
                cmd.Parameters.AddWithValue("@tipoSangre", TipoSangre);
                cmd.Parameters.AddWithValue("@tipoLicencia", TipoLicencia);

                cmd.Parameters.Add("@MsjExito", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                ConexionBD.Instance.SQLConnection.Open();
                cmd.ExecuteNonQuery();

                MensajesDesdeBD(cmd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                ConexionBD.Instance.SQLConnection.Close();
            }
        }

        /// <summary>
        /// Elimina un registro de conductor en la base de datos.
        /// </summary>
        /// <remarks>
        /// Llama al procedimiento almacenado "eliminar_conductor"
        /// </remarks>
        public void Eliminar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("eliminar_conductor", ConexionBD.Instance.SQLConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", Cedula);

                cmd.Parameters.Add("@MsjExito", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                ConexionBD.Instance.SQLConnection.Open();
                cmd.ExecuteNonQuery();

                MensajesDesdeBD(cmd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                ConexionBD.Instance.SQLConnection.Close();
            }
        }

        /// <summary>
        /// Este método será eliminado...
        /// </summary>
        /// <returns></returns>
        public DataTable MostrarConductores()
        {
            string consulta = "SELECT * FROM Conductor";
            SqlDataAdapter da = new SqlDataAdapter(consulta, ConexionBD.Instance.SQLConnection);

            using (da)
            {
                DataTable tablaConductor = new DataTable();

                da.Fill(tablaConductor);

                return tablaConductor;
            }
        }
        #endregion
    }
}
