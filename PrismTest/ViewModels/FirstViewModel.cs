using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace PrismTest.ViewModels
{
    public class FirstViewModel : BindableBase, INavigationAware
    {
        public FirstViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoSecondCommand = new DelegateCommand(GoSecond);
        }

        IRegionManager _regionManager;

        public ICommand GoSecondCommand { get; set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        private void GoSecond()
        {
            _regionManager.RequestNavigate("DrawerRegion", "SecondView");
        }
    }
}
