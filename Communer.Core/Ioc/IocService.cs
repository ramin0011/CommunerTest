using System;

namespace Communer.Core.Ioc
{
    internal class IocService 
    {
        /// <summary>
        /// Init Core & IOC
        /// </summary>
        public static void Init()
        {
            DiBase.Init();
        }


        /// <summary>
        /// Register Your Service in DI
        /// </summary>
        /// <typeparam name="TInterface">interface</typeparam>
        /// <typeparam name="T">implementation</typeparam>
        public static void RegisterService<TInterface, T>() where T : TInterface
        {
            DiBase.Instance.Register<TInterface, T>();
        }

        /// <summary>
        /// Resolve an intance of your interface from DI service
        /// </summary>
        /// <typeparam name="T">interface</typeparam>
        /// <returns>implementation</returns>
        public static T ResolveService<T>()
        {
            return DiBase.Instance.Resolve<T>();
        }
        /// <summary>
        /// Resolve an intance of your interface from DI service
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>an instance of requested type</returns>
        public static T ResolveType<T>(Type type) where T : class,new()
        {
            return DiBase.Instance.Resolve(type) as T;
        }
    }
}
