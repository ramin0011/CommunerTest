using System;
using System.Collections.Generic;

namespace Communer.Core.Models.Mvvm
{
    public class MvvmMapping
    {
        public MvvmMapping()
        {

        }
        public MvvmMapping(Type view, Type viewModel)
        {
            this.View = view;
            this.ViewModel = viewModel;
        }
        public Type ViewModel { get; set; }
        public Type View { get; set; }
    }

    public class MvvmConfig
    {
        public List<MvvmMapping> Mappings { get; set; }
        public List<MvvmMapping> Services { get; set; }
        public Type MainWindow { get; set; }
    }
}