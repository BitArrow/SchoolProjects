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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        MainWindowVM _vm = new MainWindowVM();
        static int changeStudentId;
        public AddStudentWindow()
        {
            InitializeComponent();
            changeStudentId = Methods.PassValue;
            if (changeStudentId > -1)
                ChangeName();
        }

        private void ChangeName()
        {
            lblToDo.Content = "Õpilase nime muutmine";
            getStudent();
        }

        private void getStudent()
        {
            using (DAL.DataContext db = new DAL.DataContext())
            {
                var query = from x in db.Persons where x.PersonId == changeStudentId select x;
                var quertMethodLinq = db.Persons.ToList();
                foreach (var student in quertMethodLinq)
                {
                    if (student.PersonId == changeStudentId)
                    {
                        txbFirstName.Text = student.FirstName;
                        txbLastName.Text = student.LastName;
                    }
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txbFirstName.Text != string.Empty && txbLastName.Text != string.Empty)
                AddPerson();
            else
                MessageBox.Show("Kõik väljad peavad olema täidetud!", "Teade!");
            this.Close();
        }

        private void AddPerson()
        {
            try
            {
                Models.Person student = new Models.Person();
                student.FirstName = txbFirstName.Text;
                student.LastName = txbLastName.Text;

                using (DAL.DataContext db = new DAL.DataContext())
                {
                    db.Persons.Add(student);
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
