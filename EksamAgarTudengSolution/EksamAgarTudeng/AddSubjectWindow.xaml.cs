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
using System.Windows.Shapes;
using Models;
using EksamAgarTudeng.ViewModels;

namespace EksamAgarTudeng
{
    /// <summary>
    /// Interaction logic for AddSubjectWindow.xaml
    /// </summary>
    public partial class AddSubjectWindow : Window
    {
        MainWindowVM _vm = new MainWindowVM();
        private int changeSubjectId;

        public AddSubjectWindow()
        {
            InitializeComponent();
            changeSubjectId = Methods.PassValue;
            if (changeSubjectId > -1)
                ChangeName();
        }

        private void ChangeName()
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txbNewSubject.Text != String.Empty)
                AddSubject();
            else
                MessageBox.Show("Kõik väljad peavad olema täidetud!", "Teade!");
            this.Close();
        }

        private void AddSubject()
        {
            try
            {
                Models.Subject subject = new Models.Subject();
                subject.SubjectName = txbNewSubject.Text;

                using (DAL.DataContext db = new DAL.DataContext())
                {
                    db.Subject.Add(subject);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Viga!");
            }
        }
    }
}
