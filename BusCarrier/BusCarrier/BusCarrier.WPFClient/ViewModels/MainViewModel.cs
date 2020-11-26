using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Interop;
using BusCarrier.WPFClient.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MSG = GalaSoft.MvvmLight.Messaging;

namespace BusCarrier.WPFClient.ViewModels
{
    public class MainViewModel :ViewModelBase
    {
        /// <summary>
        ///     Static instances of of the ViewModels.
        /// </summary>
        private readonly StationViewModel _stationViewModel;
        private readonly RoutesViewModel _routesViewModel;
        private readonly DashboardViewModel _dashboardViewModel;

        /// <summary>
        ///     The current view.
        /// </summary>
        private ViewModelBase _currentViewModel;

        /// <summary>
        ///     Simple property to hold the 'DashboardViewCommand' - when executed
        ///     it will change the current view to the 'DashboardView'
        /// </summary>
        public ICommand DashboardViewCommand { get; }

        /// <summary>
        ///     Simple property to hold the 'RoutesViewCommand' - when executed
        ///     it will change the current view to the 'RoutesView'
        /// </summary>
        public ICommand RoutesViewCommand { get; }

        /// <summary>
        ///     Simple property to hold the 'StationsViewCommand' - when executed
        ///     it will change the current view to the 'StationsView'
        /// </summary>
        public ICommand StationsViewCommand { get; }

        public MainViewModel(StationViewModel stationViewModel, RoutesViewModel routesViewModel, DashboardViewModel dashboardViewModel)
        {
            this._stationViewModel = stationViewModel;
            this._routesViewModel = routesViewModel;
            this._dashboardViewModel = dashboardViewModel;
            CurrentViewModel = _dashboardViewModel;
            DashboardViewCommand = new RelayCommand(() => ExecuteDashboardViewCommand());
            RoutesViewCommand = new RelayCommand(() => ExecuteRoutesViewCommand());
            StationsViewCommand = new RelayCommand(() => ExecuteStationsViewCommand());
            MSG.Messenger.Default.Register<string>(this, SelectTab);
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (value == _currentViewModel)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Set the CurrentViewModel to 'StationViewModel'
        /// </summary>
        private void ExecuteStationsViewCommand()
        {
            CurrentViewModel = _stationViewModel;
        }

        /// <summary>
        ///     Set the CurrentViewModel to 'RoutesViewModel'
        /// </summary>
        private void ExecuteRoutesViewCommand()
        {
            CurrentViewModel = _routesViewModel;
        }

        /// <summary>
        ///     Set the CurrentViewModel to 'DashboardViewModel'
        /// </summary>
        private void ExecuteDashboardViewCommand()
        {
            CurrentViewModel = _dashboardViewModel;
        }

        private void SelectTab(string tab)
        {
            switch (tab)
            {
                case ViewNames.DASHBOARD_VIEW:
                    ExecuteDashboardViewCommand();
                    break;
                case ViewNames.STATIONS_VIEW:
                    ExecuteStationsViewCommand();
                    break;
                case ViewNames.ROUTES_VIEW:
                    ExecuteDashboardViewCommand();
                    break;
                default:
                    ExecuteDashboardViewCommand();
                    break;
            }
            
        }
    }
}
