using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGalerii.Models
{
    public class SmallImage
    {
        #region private fields
        private string _fileAddress;
        private string _fileName;
        private DateTime _dateOfCreation;
        #endregion

        #region public fields
        public string FileAddress 
        { 
            get {return _fileAddress;}
            set { _fileAddress = value; } 
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; }
        }
        #endregion

        #region constructer
        public SmallImage(string fileAddress, string fileName, DateTime dateOfCreation)
        {
            this.FileAddress = fileAddress;
            this.FileName = fileName;
            this.DateOfCreation = dateOfCreation;
        }

        public SmallImage()
        {
            // TODO: Complete member initialization
        }
        #endregion
    }
}
