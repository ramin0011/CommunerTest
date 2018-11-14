using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Communer.Core.Models.Mvvm;
using Communer.Models;

namespace Communer.ViewModels
{
    public class VendingMachineVm : Communer.Core.Models.Mvvm.ViewModels.Base.ViewModelBase
    {
       public ObservableCollection<Models.Recipe> Menu { get; set; }
       public ObservableCollection<MachineLog> MachineLog { get; set; }

        private bool _canOrder=false;
        public bool CanOrder
        {
            get { return _canOrder; }
            set { _canOrder = value;RaisePropertyChanged(()=>CanOrder); }
        }

        private Recipe _selectedRecipe;

        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set { _selectedRecipe = value;RaisePropertyChanged(()=>SelectedRecipe);
                CanOrder = true;
            }
        }

        private ICommand _proccessOrder;

        public ICommand ProccessOrder
        {
            get { return _proccessOrder ?? (_proccessOrder = new CommandHandler(() => ProccessRecipe(SelectedRecipe))); }
        }

        private async void ProccessRecipe(Recipe value)
        {
            CanOrder = false;
            MachineLog=new ObservableCollection<MachineLog>();
            RaisePropertyChanged((() => MachineLog));
            MachineLog.Add(new MachineLog("MACHINE STARTED, WAITING...."));
            var machine=new Models.VendingMachine();
            machine.Log.CollectionChanged+=LogOnCollectionChanged;

            await Task.Delay(2000);
            foreach (var action in value.Steps)
            {
                await machine.ProcessItem(action.Item, action.Action);
            }
            MachineLog.Add(new MachineLog("YOUR ORDER IS READY"));
            CanOrder = true;
        }

        private void LogOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            MachineLog.Add((((eventArgs.NewItems.SyncRoot) as object[]).First() as MachineLog));
            RaisePropertyChanged(()=>MachineLog);
        }

        public VendingMachineVm()
        {
            Menu=new ObservableCollection<Recipe>();
            var recipes = Database.GetAllRecipes();
            foreach (var recipe in recipes)
            {
                Menu.Add(recipe);
            }
        }
    }
}
