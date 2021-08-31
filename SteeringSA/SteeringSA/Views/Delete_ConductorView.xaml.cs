using SteeringSA.CRUD;
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

namespace SteeringSA.Views
{
    /// <summary>
    /// Lógica de interacción para Delete_ConductorView.xaml
    /// </summary>
    public partial class Delete_ConductorView : UserControl
    {
        public Delete_ConductorView()
        {
            InitializeComponent();
            ActualizarDataGrid();
        }

        /// <summary>
        /// Botón para actualizar conductor.
        /// </summary>
        private void Btn_EliminarConductor_Click(object sender, RoutedEventArgs e)
        {
            EliminarConductorEnBD();
        }

        private void ActualizarDataGrid()
        {
            Dgv_Conductores.SelectedValuePath = "Cedula";
            Dgv_Conductores.ItemsSource = Conductor.Instance.MostrarConductores().DefaultView;
        }

        /// <summary>
        /// Llama a los metodos encargados de eliminar un conductor de la base de datos.
        /// </summary>
        private void EliminarConductorEnBD()
        {
            Conductor.Instance.Cedula = Txt_Cedula.Text;
            Conductor.Instance.Eliminar();

            ActualizarDataGrid();
        }
    }
}
