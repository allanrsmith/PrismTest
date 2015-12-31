using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace PrismTest.ViewModels
{
    public class FirstViewModel : BindableBase, INavigationAware, IActiveAware
    {
        public FirstViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            GoSecondCommand = new DelegateCommand(GoSecond);
        }

        IRegionManager _regionManager;

        public ICommand GoSecondCommand { get; set; }

        public event EventHandler IsActiveChanged;

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

        private void GoSecond()
        {
            _regionManager.RequestNavigate("DrawerRegion", "SecondView");
        }
    }
}
