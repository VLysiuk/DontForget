using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Caliburn.Micro;
using Caliburn.Micro.BindableAppBar;
using DontForget.ViewModels;

namespace DontForget
{
    public class AppBootstrapper : PhoneBootstrapperBase
    {
        private PhoneContainer _container; 

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new PhoneContainer();

            if (!Execute.InDesignMode)
            {
                _container.RegisterPhoneServices(RootFrame);
                _container.PerRequest<MainViewModel>();
                _container.PerRequest<NewListViewModel>();
                _container.PerRequest<NewListItemsViewModel>();
            }

            AddCustomConventions();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        private static void AddCustomConventions()
        {
            ConventionManager.AddElementConvention<BindableAppBarButton>(
                Control.IsEnabledProperty, "DataContext", "Click");
            ConventionManager.AddElementConvention<BindableAppBarMenuItem>(
                Control.IsEnabledProperty, "DataContext", "Click");
        }
    }
}
