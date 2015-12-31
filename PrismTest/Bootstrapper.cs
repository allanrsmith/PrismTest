using Microsoft.Practices.ServiceLocation;
using Prism.Unity;
using PrismTest.Views;
using System.Windows;

namespace PrismTest
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<FirstView>();
            Container.RegisterTypeForNavigation<SecondView>();
        }

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
