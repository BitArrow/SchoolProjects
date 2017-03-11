using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Models;
using System.Data.SqlClient;
using EksamAgarTudeng.ViewModels;
using System.Configuration;
using System.Collections.ObjectModel;

namespace EksamAgarTudeng
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;
        private int selStudentId = -1;
        private int selSubjectId = -1;
        private int selGradeId = -1;

        public MainWindow()
        {
            _vm = new MainWindowVM();
            DataContext = this._vm;
            InitializeComponent();
            StartUp();
            DisplayData();
        }

        private void DisplayData()
        {
            GetAllStudents(String.Empty,String.Empty);
            GetAllSubjects();
        }

        private void GetAllStudents(string firstName, string lastName)
        {
            using (DAL.DataContext db = new DAL.DataContext())
            {
                var query = from x in db.Persons.OrderBy(b => b.LastName).ThenByDescending(c => c.LastName).ToList() select x;
                var quertMethodLinq = db.Persons.ToList();
                foreach (var student in quertMethodLinq)
                {
                    Person newstudent = new Person();
                    newstudent.FirstName = student.FirstName;
                    newstudent.LastName = student.LastName;
                    newstudent.PersonId = student.PersonId;
                    newstudent.Grades = student.Grades;
                    if (newstudent.FirstName.ToUpper().IndexOf(firstName) > -1 && newstudent.LastName.ToUpper().IndexOf(lastName) > -1)
                    _vm.AddStudent(newstudent);
                }
            }
        }

        private void GetAllSubjects()
        {
            using (DAL.DataContext db = new DAL.DataContext())
            {
                var query = from x in db.Subject.OrderBy(b => b.SubjectName).ToList() select x;
                var quertMethodLinq = db.Subject.ToList();
                foreach (var subject in quertMethodLinq)
                {
                    Subject newsubject = new Subject();
                    newsubject.Grades = subject.Grades;
                    newsubject.SubjectId = subject.SubjectId;
                    newsubject.SubjectName = subject.SubjectName;
                    _vm.AddSubject(newsubject);
                }
            }
        }

        private void GetAllGrades()
        {
            if (selStudentId != -1 && selSubjectId != -1)
                using (DAL.DataContext db = new DAL.DataContext())
                {
                    var query = from x in db.Grades where x.PersonId == selStudentId && x.SubjectId == selSubjectId select x;   // Millegipärast ei tööta...
                    var quertMethodLinq = db.Grades.ToList();
                    foreach (var grade in quertMethodLinq)
                    {
                        if (grade.PersonId == selStudentId && grade.SubjectId == selSubjectId)
                        {
                            Grades newgrade = new Grades();
                            newgrade.Grade = grade.Grade;
                            //newgrade.Person = grade.Person;
                            newgrade.PersonId = grade.GradesId;
                            //newgrade.Subject = grade.Subject;
                            newgrade.SubjectId = grade.SubjectId;
                            _vm.AddGrades(newgrade);
                        }
                    }
                    tbAvgGrade.Text = Methods.AverageGrade(selStudentId, selSubjectId).ToString();
                }
        }

        public void StartUp()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            //AddData();
        }

        private void AddData()
        {
            var ctx = new DataContext();


            var SubjectMate = new Subject { SubjectName = "Matemaatika" };
            var SubjectCs = new Subject { SubjectName = "C#" };
            var person = new Person
            {
                FirstName = "Tauri",
                LastName = "Busch",
                Grades = new List<Grades> { 
                    new Grades { 
                        Subject = SubjectMate, 
                        Grade = 4
                    }, 
                    new Grades { 
                        Subject = SubjectCs, 
                        Grade = 5
                    }
                }
            };

            ctx.Persons.Add(person);
            ctx.SaveChanges();
        }

        private void lbxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Person person = (Person)e.AddedItems[0];
                selStudentId = person.PersonId;
            }
            catch (Exception ex)
            {
                selStudentId = -1;
            }

            _vm.ClearAllGrades();
            GetAllGrades();
        }
        private void lbxGrade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Grades grade = (Grades)e.AddedItems[0];
                selGradeId = grade.GradesId;
            }
            catch (Exception ex)
            {
                selGradeId = -1;
            }
        }

        private void lbxSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Subject subject = (Subject)e.AddedItems[0];
                selSubjectId = subject.SubjectId;
            }
            catch (Exception ex)
            {
                selSubjectId = -1;
            }
            _vm.ClearAllGrades();
            GetAllGrades();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Methods.PassValue = -1;
            AddStudentWindow addStud = new AddStudentWindow();
            addStud.Show();
        }

        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            Methods.PassValue = -1;
            AddSubjectWindow addSub = new AddSubjectWindow();
            addSub.Show();
        }



        private void btnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            int newGrade = 0;
            if (selSubjectId > -1 && selStudentId > -1)
            {
                try
                {
                    newGrade = Convert.ToInt32(tbAddGrade.Text);
                }
                catch (Exception exc) {}
                if (newGrade <= 5 && newGrade >= 1)
                {
                    try
                    {
                        Models.Grades addGrade = new Grades();
                        addGrade.Grade = newGrade;
                        addGrade.PersonId = selStudentId;
                        addGrade.SubjectId = selSubjectId;

                        using (DAL.DataContext db = new DAL.DataContext())
                        {
                            db.Grades.Add(addGrade);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Viga!");
                    }
                }
                else
                    MessageBox.Show("Hinne peab olema täisarv vahemikus 1-5!", "Teade!");
                tbAddGrade.Text = String.Empty;
                _vm.ClearAllGrades();
                GetAllGrades();
            }
            else
                MessageBox.Show("Hinde sisestamiseks valige õpilane ja aine!", "Teade!");
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            lbxGrade.UnselectAll();
            lbxStudent.UnselectAll();
            lbxSubject.UnselectAll();
            _vm.ClearAllLists();
            GetAllStudents(string.Empty,string.Empty);
            GetAllSubjects();
            selGradeId = selStudentId = selSubjectId = -1;
        }

        private void btnSearchPerson_Click(object sender, RoutedEventArgs e)
        {
            string first = tbFindFirstName.Text.ToUpper();
            string last = tbFindLastName.Text.ToUpper();
            _vm.ClearAllLists();
            GetAllStudents(first, last);
            GetAllSubjects();
        }

        private void lbxStudent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Methods.PassValue = selStudentId;
            AddStudentWindow addSub = new AddStudentWindow();
            addSub.Show();
        }

        private void lbxSubject_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Methods.PassValue = selSubjectId;
            AddSubjectWindow addSub = new AddSubjectWindow();
            addSub.Show();
        }

        private void lbxGrade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        
    }
}
/*
An unhandled exception of type 'System.InvalidOperationException' occurred in PresentationFramework.dll

Additional information: Operation is not valid while ItemsSource is in use. Access and modify elements with ItemsControl.ItemsSource instead.
*/