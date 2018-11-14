using System.Threading.Tasks;
using Communer.Core.Ioc;
using Communer.Core.Models.Interfaces;
using Communer.Core.Models.Mvvm;
using Communer.Core.Mvvm.Services;

namespace Communer.Core
{
    public class Core
    {
        /// <summary>
        /// Initialize App Core Structure
        /// </summary>
        /// <param name="mvvmConfig">Mvvm configurations</param>
        public static async Task Init(MvvmConfig mvvmConfig=null)
        {
            IocService.Init();
            RegisterServices(mvvmConfig);
            if (mvvmConfig?.Mappings != null)
                await RunApp(mvvmConfig);
        }

        private static void RegisterServices(MvvmConfig mvvmConfig = null)
        {
            IocService.RegisterService<IMessagingCenter, MessagingCenter>();
            IocService.RegisterService<INavigationService, NavigationService>();
        }

        private static async Task RunApp(MvvmConfig mvvmConfig)
        {
            var nav = IocService.ResolveService<INavigationService>();
            await nav.InitializeAsync(mvvmConfig.MainWindow, mvvmConfig.Mappings);
        }

        /// <summary>
        /// Register Your Service in DI
        /// </summary>
        /// <typeparam name="TInterface">interface</typeparam>
        /// <typeparam name="T">implementation</typeparam>
        public static void RegisterService<TInterface, T>() where T : TInterface
        {
            IocService.RegisterService<TInterface, T>();
        }

        /// <summary>
        /// Resolve an intance of your interface from DI service
        /// </summary>
        /// <typeparam name="T">interface</typeparam>
        /// <returns>implementation</returns>
        public static T ResolveService<T>()
        {
            return IocService.ResolveService<T>();
        }
        
        /// <summary>
        /// Resolve an intance of your interface from DI service
        /// </summary>
        /// <typeparam name="T">interface</typeparam>
        /// <returns>implementation</returns>
        public static T ResolveViewModel<T>() where T : class, new()
        {
            return IocService.ResolveType<T>(typeof(T));
        }
    }
}
