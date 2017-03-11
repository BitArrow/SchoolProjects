using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace EksamAgarTudeng.ViewModels
{
    public class MainWindowVM
    {
        private ObservableCollection<Person> _student;
        private ObservableCollection<Subject> _subject;
        private ObservableCollection<Grades> _grades;
        public ObservableCollection<Person> Person
        {
            get { return _student; }
            set { _student = value; }
        }
        public ObservableCollection<Subject> Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public ObservableCollection<Grades> Grades
        {
            get { return _grades; }
            set { _grades = value; }
        }

        internal void AddStudent(Person student)
        {
            _student.Add(student);
        }

        internal void AddSubject(Subject newSubject)
        {
            _subject.Add(newSubject);
        }

        internal void AddGrades(Grades newGrade)
        {
            _grades.Add(newGrade);
        }

        public void ClearAllLists()
        {
            Person.Clear();
            Subject.Clear();
            Grades.Clear();
        }

        public void ClearAllGrades()
        {
            Grades.Clear();
        }

        public MainWindowVM()
        {
            this._student = new ObservableCollection<Person>();
            this._subject = new ObservableCollection<Subject>();
            this._grades = new ObservableCollection<Grades>();
        }
    }
}
