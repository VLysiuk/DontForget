using Caliburn.Micro;

namespace DontForget.ViewModels
{
    public class NewListItemsViewModel : PropertyChangedBase
    {
        private string _listName;

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
            }
        }
    }
}
