using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MLReader
{
    public class LOPageSource
    {
        public LOPageSource()
        { 
        }


        private BitmapImage _cover;

        public BitmapImage Cover
        {
            get { return _cover; }
            set { _cover = value; }
        }
        

        private List<LOSlideSource> _slides;

        public List<LOSlideSource> Slides
        {
            get { return _slides; }
            set { _slides = value; }
        }
        
    }
}
