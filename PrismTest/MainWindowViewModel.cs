using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace PrismTest
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        IRegionManager _regionManager;

        public ICommand NavigateCommand { get; set; }

        private void Navigate()
        {
            _regionManager.RequestNavigate("DrawerRegion", "FirstView");
        }
    }
}
