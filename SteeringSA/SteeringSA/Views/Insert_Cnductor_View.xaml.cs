using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using SteeringSA.CRUD;

namespace SteeringSA.Views
{
    /// <summary>
    /// Lógica de interacción para Insert_Cnductor_View.xaml
    /// </summary>
    public partial class Insert_Cnductor_View : UserControl
    {
        public Insert_Cnductor_View()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón para registrar conductor.
        /// </summary>
        private void Btn_RegistrarConductor_Click(object sender, RoutedEventArgs e)
        {
            RegistrarConductorEnBD();
        }

        /// <summary>
        /// Llama a los metodos encargados de registrar un conductor en la base de datos.
        /// </summary>
        private void RegistrarConductorEnBD()
        {
            Conductor.Instance.Cedula = Txt_Cedula.Text;
            Conductor.Instance.Nombre = Txt_Nombre.Text;
            Conductor.Instance.Apellido = Txt_Apellido.Text;
            Conductor.Instance.Telefono = Txt_Telefono.Text;
            Conductor.Instance.FechaNacimiento = Dtp_FechaNac.Text;
            Conductor.Instance.TipoSangre = Txt_TipoSangre.Text;
            Conductor.Instance.TipoLicencia = Txt_TipoLicencia.Text;
            Conductor.Instance.Registrar();
        }
    }
}
