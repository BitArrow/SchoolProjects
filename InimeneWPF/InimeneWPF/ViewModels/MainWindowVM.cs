using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using InimeneWPF.Models;

namespace InimeneWPF.ViewModels
{
    public class MainWindowVM
    {
        #region private fields

        private ObservableCollection<Inimene> _inimesed;


        #endregion

        #region public properties

        public ObservableCollection<Inimene> Inimesed
        {
            get { return _inimesed; }
        }

        #endregion

        #region constructor

        public MainWindowVM()
        {
            this._inimesed = new ObservableCollection<Inimene>();
        }

        #endregion

        #region methods

        public void lisaInimene(Inimene inim)
        {
            _inimesed.Add(inim);
        }

        #endregion

    }
}
