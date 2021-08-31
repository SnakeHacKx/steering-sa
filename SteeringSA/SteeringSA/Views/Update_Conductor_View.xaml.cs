using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SteeringSA.CRUD;

namespace SteeringSA.Views
{
    /// <summary>
    /// Lógica de interacción para Update_Conductor_View.xaml
    /// </summary>
    public partial class Update_Conductor_View : UserControl
    {
        public Update_Conductor_View()
        {
            InitializeComponent();
            MostrarConductores();
        }

        /// <summary>
        /// Botón para actualizar conductor.
        /// </summary>
        private void Btn_ActualizarConductor_Click(object sender, RoutedEventArgs e)
        {
            ActualizarConductorEnBD();
        }

        /// <summary>
        /// Este método será eliminado...
        /// </summary>
        private void MostrarConductores()
        {
            string consulta = "SELECT * FROM Conductor";
            SqlDataAdapter da = new SqlDataAdapter(consulta, ConexionBD.Instance.SQLConnection);

            using (da)
            {
                DataTable tablaConductor = new DataTable();

                da.Fill(tablaConductor);

                Dgv_Conductores.SelectedValuePath = "Cedula";
                Dgv_Conductores.ItemsSource = tablaConductor.DefaultView;
            }
        }

        /// <summary>
        /// Llama a los metodos encargados de actualizar un conductor en la base de datos.
        /// </summary>
        private void ActualizarConductorEnBD()
        {
            Conductor.Instance.Cedula = Txt_Cedula.Text;
            Conductor.Instance.Nombre = Txt_Nombre.Text;
            Conductor.Instance.Apellido = Txt_Apellido.Text;
            Conductor.Instance.Telefono = Txt_Telefono.Text;
            Conductor.Instance.FechaNacimiento = Dtp_FechaNac.Text;
            Conductor.Instance.TipoSangre = Txt_TipoSangre.Text;
            Conductor.Instance.TipoLicencia = Txt_TipoLicencia.Text;
            Conductor.Instance.Actualizar();
            MostrarConductores();
        }
    }
}
