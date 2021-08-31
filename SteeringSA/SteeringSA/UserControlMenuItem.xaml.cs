using BeautySolutions.View.ViewModel;
using SteeringSA.ViewModel;
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

namespace SteeringSA
{
    /// <summary>
    /// Lógica de interacción para UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        public UserControlMenuItem(ItemMenu itemMenu)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMenu.SelectedIndex == 0)
            {
                DataContext = new ConductorViewModel();
            }

            if (ListViewMenu.SelectedIndex == 1)
            {
                //DataContext = new VehiculoViewModel();
            }

            if (ListViewMenu.SelectedIndex == 2)
            {
                MessageBox.Show("Se presiono Servicio");
            }

            if (ListViewMenu.SelectedIndex == 3)
            {
                MessageBox.Show("Se presiono Mantenimiento");
            }

            if (ListViewMenu.SelectedIndex == 4)
            {
                MessageBox.Show("Se presiono Reporte");
            }
        }
    }
}
