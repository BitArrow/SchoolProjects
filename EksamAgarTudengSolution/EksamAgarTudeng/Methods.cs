using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamAgarTudeng.ViewModels
{
    public class Methods
    {
        public static int _passId = -1;
        public static int PassValue
        {
            get { return _passId; }
            set { _passId = value; }
        }

        public static double AverageGrade(int stu, int sub)
        {
            double avr = 0, nrOfGrades = 0;
            var ctx = new DataContext();
            foreach (var grade in ctx.Grades)
            {
                if (grade.PersonId == stu && grade.SubjectId == sub)
                { 
                    avr += grade.Grade;
                    nrOfGrades++;
                }
            }
            if (nrOfGrades > 0)
                return avr / nrOfGrades;
            else
                return 0;
        }
    }
}
