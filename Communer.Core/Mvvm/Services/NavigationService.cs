using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Communer.Core.Ioc;
using Communer.Core.Models.Interfaces;
using Communer.Core.Models.Mvvm;
using Communer.Core.Models.Mvvm.ViewModels.Base;

namespace Communer.Core.Mvvm.Services
{
    
    public class NavigationService : INavigationService
    {
        protected static Dictionary<Type, Type> Mappings;
        private DiBase ioc;
        private Type LaunchingPage { get; set; }

        public NavigationService()
        {
            if(Mappings==null)
            Mappings = new Dictionary<Type, Type>();
            this.ioc = DiBase.Instance;
        }
        public Task InitializeAsync(Type mainPage, List<MvvmMapping> mapping)
        {
            LaunchingPage = mainPage;

            Mappings.Clear();
                foreach (var map in mapping)
                {
                    Mappings.Add(map.ViewModel, map.View);
                }

            return InternalNavigateToAsync(Mappings.First(a => a.Value == LaunchingPage).Key, null);

        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }
        public Task NavigateToAsync<TViewModel>(params object[] parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }
        public Task NavigateToAsync(Type viewModelType, params object[] parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, params object[] parameter)
        {
            Window page = CreateAndBindPage(viewModelType, parameter);
            await ((ViewModelBase) page.DataContext).InitializeAsync(parameter);

            if (page.GetType() == LaunchingPage && Application.Current.Windows.Count<2)
            {
                Application.Current.MainWindow = page;
                Application.Current.MainWindow.Show();
            }
            else 
            {
                page.Show();
            }
        }

        protected Window CreateAndBindPage(Type viewModelType, params object[] parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Window page;
            if (parameter != null && parameter.Any())
            {
                try
                {
                    var ctor = pageType.GetConstructor(new[] { parameter[0].GetType() });
                    if (ctor != null)
                        page = ctor.Invoke(new[] { parameter.First() }) as Window;
                    else
                        // if the page class doesnt have the constructor requested , create the page and pass the parameteres to viewmodel instead
                        page = Activator.CreateInstance(pageType) as Window;
                }
                // ReSharper disable once RedundantCatchClause
                catch
                {
                    throw;
                }
            }
            else
                page = Activator.CreateInstance(pageType) as Window;

            var viewModel = ioc.Resolve(viewModelType);
            if (page != null && page.DataContext == null)
                page.DataContext = viewModel;

            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!Mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return Mappings[viewModelType];
        }
    }
}
