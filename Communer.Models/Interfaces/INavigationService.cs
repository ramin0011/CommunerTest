using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Communer.Core.Models.Mvvm;
using Communer.Core.Models.Mvvm.ViewModels.Base;

namespace Communer.Core.Models.Interfaces
{
    public interface INavigationService
    {
        Task InitializeAsync(Type mainPage, List<MvvmMapping> mapping);
        Task NavigateToAsync(Type viewModelType);
        Task NavigateToAsync<TViewModel>(params object[] parameter) where TViewModel : ViewModelBase;
        Task NavigateToAsync(Type viewModelType, params object[] parameter);
    }
}