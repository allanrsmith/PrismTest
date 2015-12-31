using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;
using System;
using Prism;

namespace PrismTest.ViewModels
{
    public class SecondViewModel : BindableBase, INavigationAware
    {
        public SecondViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        IRegionManager _regionManager;

        public ICommand GoBackCommand { get; set; }

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

        private void GoBack()
        {
            var region = _regionManager.Regions["DrawerRegion"];
            if (!region.NavigationService.Journal.CanGoBack) { return; }
            region.NavigationService.Journal.GoBack();
        }
    }
}
