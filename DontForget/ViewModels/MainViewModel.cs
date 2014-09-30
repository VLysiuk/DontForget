using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DontForget.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void AddNewList()
        {
            _navigationService.UriFor<NewListViewModel>().Navigate();
        }
    }
}
