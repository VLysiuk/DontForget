using Caliburn.Micro;

namespace DontForget.ViewModels
{
    public class NewListViewModel : PropertyChangedBase
    {
        private readonly INavigationService _navigationService;

        private string _listName;

        public NewListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string ListName
        {
            get
            {
                return _listName;
            }

            set
            {
                _listName = value;
                NotifyOfPropertyChange(() => ListName);
                NotifyOfPropertyChange(() => CanAccept);
            }
        }

        public bool CanAccept
        {
            get { return !string.IsNullOrEmpty(ListName); }
        }

        public void Accept()
        {
            _navigationService.UriFor<NewListItemsViewModel>().WithParam(_ => _.ListName, ListName).Navigate();
        }

        public void Cancel()
        {
            _navigationService.GoBack();
        }
    }
}
