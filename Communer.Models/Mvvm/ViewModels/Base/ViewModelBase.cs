using System.Threading.Tasks;
using Communer.Core.Models.Interfaces;
using Unity.Attributes;

namespace Communer.Core.Models.Mvvm.ViewModels.Base
{
    public abstract class ViewModelBase :ExtendedBindableObject
    {
        [Dependency]
        protected INavigationService NavigationService { get; set; }
        [Dependency]
        protected IMessagingCenter MessagingCenter { get; set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(()=>IsBusy);
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
