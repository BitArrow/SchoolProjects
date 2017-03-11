using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPFGalerii.Models;
using WPFGalerii.ViewModels;
// Tekib konflikt WPF'i ja Windows.Forms konfliktidega.
// Saab tekitada aliase, mida saab kasutada lühidana, ilma et peaks praegusel juhul koguaeg pikalt välja kirjutama
using Forms = System.Windows.Forms;

namespace WPFGalerii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAva_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //if (fileDialog.ShowDialog().HasValue)
            //    txbURL.Text = fileDialog.FileName;

            Forms.FolderBrowserDialog folderDialog = new Forms.FolderBrowserDialog();
            if (folderDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                _vm = new MainWindowVM();
                txbURL.Text = folderDialog.SelectedPath;
                DisplaySmallImages(folderDialog.SelectedPath);

                
                //_vm.laeAndmed();
                this.DataContext = _vm;
            }
        }

        private void DisplaySmallImages(string path)
        {
            //SmallImage newSmallImage = new SmallImage();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            var images = dirInfo.GetFiles("*.jpg");
            foreach (var image in images)
            {
                SmallImage newSmallImage = new SmallImage();
                newSmallImage.FileAddress = image.FullName;
                newSmallImage.FileName = image.Name;
                newSmallImage.DateOfCreation = image.CreationTime;
                _vm.AddSmallImage(newSmallImage);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm = new MainWindowVM();
            //_vm.BigImage = lboxSmallImages.SelectedValue;
        }
    }
}
