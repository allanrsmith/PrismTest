using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;
using System;
using Prism;

namespace PrismTest.ViewModels
{
    public class SecondViewModel : BindableBase, INavigationAware, IActiveAware
    {
        public SecondViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        IRegionManager _regionManager;

        public event EventHandler IsActiveChanged;

        public ICommand GoBackCommand { get; set; }

        bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

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
