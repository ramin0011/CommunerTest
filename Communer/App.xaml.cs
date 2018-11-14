using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Communer.Core.Models.Mvvm;
using Communer.ViewModels;

namespace Communer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MvvmConfig mvvmConfig = new MvvmConfig()
        {
            MainWindow = typeof(Views.MainWindow),
            Mappings = new List<MvvmMapping>()
            {
                new MvvmMapping(typeof(Views.MainWindow),typeof(ViewModels.MainWindowVm)),
                new MvvmMapping(typeof(Views.VendingMachineWindow),typeof(ViewModels.VendingMachineVm)),
            }
        };

        public App()
        {
            RunApp();
        }

        private async void RunApp()
        {
            await Core.Core.Init(mvvmConfig);
        }
    }
}
