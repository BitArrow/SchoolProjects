using InimeneWPF.Models;
using InimeneWPF.ViewModels;
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

namespace InimeneWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Inimene> _inimesed;
        private Inimene _valitud;
        private MainWindowVM _vm;

        public MainWindow()
        {
            InitializeComponent();
            _inimesed = new List<Inimene>();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new MainWindowVM();
            this.DataContext = _vm;
        }

        private void btnValmis_Click(object sender, RoutedEventArgs e)
        {
            if (lbInimesed.SelectedIndex < 0)
            {
                int vanus = Convert.ToInt32(txtVanus.Text);
                Inimene uusInimene = new Inimene(txtEesnimi.Text, txtPerenimi.Text, vanus);
                _vm.lisaInimene(uusInimene);
            }
            else
            { 
                lbInimesed.SelectedIndex = -1;
            }
            clearFields();
        }

        private void clearFields()
        {
            txtEesnimi.Text = "";
            txtPerenimi.Text = "";
            txtVanus.Text = "";
        }

        private void lbInimesed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbInimesed.SelectedIndex > -1)
            {
                btnValmis.Content = "Muuda";
                return;
            }
            btnValmis.Content = "Valmis";
        }
    }
}
