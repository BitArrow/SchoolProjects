using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGalerii.Models;

namespace WPFGalerii.ViewModels
{
    public class MainWindowVM
    {
        private ObservableCollection<SmallImage> _smallImages;
        private String _bigImageSource;


        public ObservableCollection<SmallImage> SmallIamges
        {
            get { return _smallImages; }
            set { _smallImages = value; }
        }

        public String BigImage
        {
            get { return _bigImageSource; }
            set { _bigImageSource = value; }
        }
            

        public MainWindowVM()
        {
            this._smallImages = new ObservableCollection<SmallImage>();
        }

        internal void AddSmallImage(SmallImage newSmallImage)
        {
            _smallImages.Add(newSmallImage);
        }

        public void laeAndmed()
        {
            _smallImages.Add(new SmallImage());
        }
        
    }
}
