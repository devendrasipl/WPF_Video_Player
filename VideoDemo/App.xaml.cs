using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VideoDemo.ViewModel;

namespace VideoDemo
{ 
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();

            //Register ViewModel
            container.RegisterType<ISampleViewModel, SampleViewModel>();

            //Set Service Locator
            var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            //var window = container.Resolve<MainWindow>();
            //window.Show();
        }
    }
}
