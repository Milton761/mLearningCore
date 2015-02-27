using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;


namespace MLReader
{
    public sealed partial class LOReaderView : Grid
    {
        double DeviceHeight = 900.0, DeviceWidth = 1600.0; 

        public LOReaderView()
        {
            init();
            tmpload();
        }

        ScrollViewer _mainscroll;
        StackPanel _contentpanel;
        CompositeTransform _ctrasnform;
        int _pointers = 0,  _currentindex;
        bool _forcemanipulation2end = false;
        double _initthreshold = 0.0, _finalthreshold = 0.0;
        double _currentposition = -0.0;

        void init()
        {
            Height = DeviceHeight;
            Width = DeviceWidth;

            _mainscroll = new ScrollViewer() 
            {
                VerticalScrollMode =  ScrollMode.Disabled,
                VerticalScrollBarVisibility = ScrollBarVisibility.Disabled ,
                HorizontalScrollBarVisibility =  ScrollBarVisibility.Hidden,
                HorizontalScrollMode = ScrollMode.Enabled,
                Width = DeviceWidth,
                Height = DeviceHeight
            };
            Children.Add(_mainscroll);

            _contentpanel = new StackPanel() 
            {
                ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All,
                Height = DeviceHeight,
                Orientation = Orientation.Horizontal
            };
            _mainscroll.Content = _contentpanel;

            _ctrasnform = new CompositeTransform();
            _contentpanel.RenderTransform = _ctrasnform;

            //events
            ManipulationMode = ManipulationModes.All;
            PointerPressed += LOReaderView_PointerPressed;
            PointerCanceled += LOReaderView_PointerCanceled;
            PointerReleased += LOReaderView_PointerReleased;
            ManipulationStarted += LOReaderView_ManipulationStarted;
            ManipulationDelta += LOReaderView_ManipulationDelta;
            ManipulationCompleted += LOReaderView_ManipulationCompleted;
            ManipulationInertiaStarting += LOReaderView_ManipulationInertiaStarting;
        }


        #region properties

        private List<LOPageSource> _source;

        public List<LOPageSource> Source
        {
            get { return _source; }
            set { _source = value; loadsource(); }
        }
        

        #endregion

        #region functions

        void loadsource()
        {
            for (int i = 0; i < _source.Count; i++)
            {
                Image img = new Image()
                {
                    Width = DeviceWidth,
                    Height = DeviceHeight,
                    Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill,
                    Source = _source[i].Cover
                };
                _contentpanel.Children.Add(img);
            }
        }

        void tmpload()
        {
            for (int i = 0; i < 6; i++)
            {
                 Image img = new Image()
                {
                    Width = DeviceWidth,
                    Height = DeviceHeight,
                    Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill,
                    Source = new BitmapImage(new Uri("ms-appx:///1_2.jpg"))
                };
                _contentpanel.Children.Add(img);
            }
            _finalthreshold = -5.0 * DeviceWidth;
        }


        void LOReaderView_PointerReleased(object sender, PointerRoutedEventArgs e)
        { 
            _forcemanipulation2end = true;
        }

        void LOReaderView_PointerCanceled(object sender, PointerRoutedEventArgs e)
        { 
            _forcemanipulation2end = true;
        }

        void LOReaderView_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _pointers += 1; 
        }


        void LOReaderView_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
        }

        void LOReaderView_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (_forcemanipulation2end || e.IsInertial) e.Complete();

            if (_pointers > 1)
            {

            }
            else
            {
                //_ctrasnform.TranslateX += e.Delta.Translation.X;
                if (_currentposition < _initthreshold && _currentposition > _finalthreshold)
                {
                    _currentposition += e.Delta.Translation.X;
                }
                else 
                {
                    _currentposition += (e.Delta.Translation.X * 0.4);
                }
                _ctrasnform.TranslateX = _currentposition;
            }
        }

        void LOReaderView_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingRoutedEventArgs e)
        {
        }

        void LOReaderView_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (_pointers > 1)
            { 
            }
            else 
            {
                if (Math.Abs( e.Velocities.Linear.X) > -4.5)
                {
                    if (e.Velocities.Linear.X > 0) _currentindex -= 1;
                    else _currentindex += 1; 
                }
                else
                {
                    if (_currentposition < -1.0 * (DeviceWidth * _currentindex + DeviceWidth / 2.0))
                        _currentindex += 1;

                    if (_currentposition > -1.0 * (DeviceWidth * _currentindex - DeviceWidth / 2.0))
                        _currentindex -= 1;
                }
                animate2index(_currentindex);
            }

            _pointers = 0;
            _forcemanipulation2end = false; 
        }

        void animate2index(int index)
        {
            if (_currentindex < 0) _currentindex = 0;
            _currentposition = -1.0 * DeviceWidth * _currentindex;
            animate2double(_currentposition);
            _forcemanipulation2end = false;
        }


        void animate2double(double to)
        {
            Storyboard story = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(350);

            Storyboard.SetTarget(animation,_ctrasnform);
            Storyboard.SetTargetProperty(animation, "TranslateX");

            animation.To = to;
            story.Children.Add(animation);
            story.Begin();
            story.Completed += story_Completed;

        }

        void story_Completed(object sender, object e)
        {
            _forcemanipulation2end = false;
        }

        #endregion

    }
}
