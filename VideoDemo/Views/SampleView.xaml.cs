using Microsoft.Practices.ServiceLocation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VideoDemo.ViewModel;

namespace VideoDemo.Views
{
    /// <summary>
    /// Interaction logic for SampleView.xaml
    /// </summary>
    public partial class SampleView : UserControl
    {
        private readonly SampleViewModel _viewModel;

        public SampleView()
        {
            InitializeComponent();

            _viewModel = ServiceLocator.Current.GetInstance(typeof(SampleViewModel)) as SampleViewModel;
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Canvas.SetZIndex(canvasPlayer, 99);
                bool isMediaClosed = false;

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(10);

                MediaPlayer mp = new MediaPlayer();
                var bgVideoPath = Environment.CurrentDirectory + @"\Touchdown.mp4";
                mp.Open(new Uri(bgVideoPath));

                VideoDrawing vd = new VideoDrawing();
                vd.Player = mp;
                vd.Rect = new Rect(0, 0, 100, 100);

                DrawingBrush db = new DrawingBrush(vd);

                var btnBg = MainCanvas.Background;

                // Affect the drawing brush as a background for all 9 buttons
                //foreach (Button b in videoGrid.Children)
                canvasPlayer.Background = db;

                // Lecture!
                mp.Play();
                timer.Start();

                timer.Tick += (t, l) =>
                {
                    timer.Stop();
                    if (!isMediaClosed)
                    {
                        mp.Stop();
                        mp.Close();

                        canvasPlayer.Background = btnBg;
                        Canvas.SetZIndex(canvasPlayer, -1);
                        isMediaClosed = true;
                    }
                };

                mp.MediaEnded += (k, p) =>
                {
                    mp.Stop();
                    mp.Close();

                    canvasPlayer.Background = btnBg;
                    Canvas.SetZIndex(canvasPlayer, -1);
                    isMediaClosed = true;
                };

            }
            catch (Exception)
            {
            }
        }
    }
}
