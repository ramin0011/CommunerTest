using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Communer.Core.Models.Mvvm;

namespace Communer.ViewModels
{
    public class MainWindowVm:Communer.Core.Models.Mvvm.ViewModels.Base.ViewModelBase
    {
        private ICommand _startMachine;

        public ICommand StartVendingMachine
        {
            get { return _startMachine ?? (_startMachine = new CommandHandler(OpenVendingMachineWindow)); }
        }

        private async void OpenVendingMachineWindow()
        {
           await NavigationService.NavigateToAsync<ViewModels.VendingMachineVm>();
        }
    }
}
