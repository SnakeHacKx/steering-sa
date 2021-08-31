using System;
using System.Collections.Generic;
using BeautySolutions.View.ViewModel;
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
using MaterialDesignThemes.Wpf;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SteeringSA.ViewModel;

namespace SteeringSA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> botones = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            ConexionBD.Instance.InicializarConxion();
            MostrarConductores();

            botones.Add(Btn_Registrar);
            botones.Add(Btn_Actualizar);
            botones.Add(Btn_Eliminar);

            #region BOTONES SIDE MENU
            //var menuRegister = new List<SubItem>();
            //menuRegister.Add(new SubItem("Conductor"));
            //menuRegister.Add(new SubItem("Vehículo"));
            //menuRegister.Add(new SubItem("Servicio"));
            //menuRegister.Add(new SubItem("Mantenimiento"));
            //menuRegister.Add(new SubItem("Reporte"));
            //var item6 = new ItemMenu("Registrar", menuRegister, PackIconKind.Register);

            //var menuUpdate = new List<SubItem>();
            //menuUpdate.Add(new SubItem("Conductor"));
            //menuUpdate.Add(new SubItem("Vehículo"));
            //menuUpdate.Add(new SubItem("Servicio"));
            //menuUpdate.Add(new SubItem("Mantenimiento"));
            //var item1 = new ItemMenu("Actualizar", menuUpdate, PackIconKind.Update);

            //var menuDelete = new List<SubItem>();
            //menuDelete.Add(new SubItem("Conductor"));
            //menuDelete.Add(new SubItem("Vehículo"));
            //menuDelete.Add(new SubItem("Servicio"));
            //menuDelete.Add(new SubItem("Mantenimiento"));
            //var item2 = new ItemMenu("Eliminar", menuDelete, PackIconKind.Delete);

            //var menuConsult = new List<SubItem>();
            //menuConsult.Add(new SubItem("Conductor"));
            //menuConsult.Add(new SubItem("Vehículo"));
            //menuConsult.Add(new SubItem("Servicio"));
            //menuConsult.Add(new SubItem("Mantenimiento"));
            //var item3 = new ItemMenu("Consultar", menuConsult, PackIconKind.Database);

            //var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            //menu.Children.Add(new UserControlMenuItem(item0));
            //menu.Children.Add(new UserControlMenuItem(item6));
            //menu.Children.Add(new UserControlMenuItem(item1));
            //menu.Children.Add(new UserControlMenuItem(item2));
            //menu.Children.Add(new UserControlMenuItem(item3));
            #endregion
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

                DataGridConductores.SelectedValuePath = "Cedula";
                DataGridConductores.ItemsSource = tablaConductor.DefaultView;
            }
        }

        /// <summary>
        /// Boton que lleva a la pantalla de registro
        /// </summary>
        private void Btn_Registrar_Click(object sender, RoutedEventArgs e)
        {
            if (Cb_Entidad.SelectedIndex == 0)
                DataContext = new Insert_ConductorViewModel();
            else if (Cb_Entidad.SelectedIndex == 1)
                MessageBox.Show("Se ha elegido la entidad Vehiculo... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 2)
                MessageBox.Show("Se ha elegido la entidad Servicio... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 3)
                MessageBox.Show("Se ha elegido la entidad Mantenimiento... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 4)
                MessageBox.Show("Se ha elegido la entidad Reporte... Falta por programar...");
            else return;

            CambiarColorDeBoton(Btn_Registrar, "#F8485E");
            Tb_TituloVentana.Text = "Registrar Conductor";
        }

        /// <summary>
        /// Boton que lleva a la pantalla de actualizacion
        /// </summary>
        private void Btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (Cb_Entidad.SelectedIndex == 0)
                DataContext = new Update_ConductorViewModel();
            else if (Cb_Entidad.SelectedIndex == 1)
                MessageBox.Show("Se ha elegido la entidad Vehiculo... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 2)
                MessageBox.Show("Se ha elegido la entidad Servicio... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 3)
                MessageBox.Show("Se ha elegido la entidad Mantenimiento... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 4)
                MessageBox.Show("Se ha elegido la entidad Reporte... Falta por programar...");
            else return;

            CambiarColorDeBoton(Btn_Actualizar, "#F8485E");
            Tb_TituloVentana.Text = "Actualizar Conductor";
        }

        /// <summary>
        /// Boton que lleva a la pantalla de eliminacion
        /// </summary>
        private void Btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Cb_Entidad.SelectedIndex == 0)
                DataContext = new Delete_ConductorViewModel();
            else if (Cb_Entidad.SelectedIndex == 1)
                MessageBox.Show("Se ha elegido la entidad Vehiculo... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 2)
                MessageBox.Show("Se ha elegido la entidad Servicio... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 3)
                MessageBox.Show("Se ha elegido la entidad Mantenimiento... Falta por programar...");
            else if (Cb_Entidad.SelectedIndex == 4)
                MessageBox.Show("Se ha elegido la entidad Reporte... Falta por programar...");
            else return;

            CambiarColorDeBoton(Btn_Eliminar, "#F8485E");
            Tb_TituloVentana.Text = "Eliminar Conductor";
        }

        /// <summary>
        /// Cambia de color un boton.
        /// </summary>
        /// <param name="boton">Boton al que se le desea cambiar el color</param>
        /// <param name="color">Nuevo color que se desea poner en el botón</param>
        private void CambiarColorDeBoton(Button boton, string color)
        {
            BrushConverter bc = new BrushConverter();

            foreach (Button b in botones)
            {
                if (b.Background.ToString() == ((Brush)bc.ConvertFrom(color)).ToString())
                {
                    b.Background = (Brush)bc.ConvertFrom("#2196F3");
                    b.BorderBrush = (Brush)bc.ConvertFrom("#2196F3");
                }
            }

            boton.Background = (Brush)bc.ConvertFrom(color);
            boton.BorderBrush = (Brush)bc.ConvertFrom(color);
        }
    }
}
