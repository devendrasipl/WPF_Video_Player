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
using VideoDemo.ViewModel;

namespace VideoDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private readonly SampleViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = ServiceLocator.Current.GetInstance(typeof(SampleViewModel)) as SampleViewModel;
            this.DataContext = _viewModel;
        }
    }
}
