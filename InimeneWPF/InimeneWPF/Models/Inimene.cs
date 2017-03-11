using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InimeneWPF.Models
{
    public class Inimene
    {
        #region private fields

        private string _eesnimi;
        private string _perenimi;
        private int _vanus;

        #endregion

        #region public properties

        public string Eesnimi
        {
            get { return _eesnimi; }
            set { _eesnimi = value; }
        }
        public string Perenimi
        {
            get { return _perenimi; }
            set { _perenimi = value; }
        }
        public int Vanus
        {
            get { return _vanus; }
            set { _vanus = value; }
        }

        #endregion

        #region constructor

        public Inimene(string eesnimi, string perenimi, int vanus)
        {
            this.Eesnimi = eesnimi;
            this.Perenimi = perenimi;
            this.Vanus = vanus;
        }

        #endregion

    }
}
