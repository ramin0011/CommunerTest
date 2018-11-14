using System;
using Communer.Core.Models.Interfaces;
using Unity;
using Unity.Lifetime;

namespace Communer.Core.Ioc
{
    internal class DiBase : IDiBase
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if(_container==null)
                    _container=new UnityContainer();
                return _container;
            }
        }

        private static DiBase _instance = null;

        internal static DiBase Instance
        {
            get
            {
                return _instance;
            }
            private set { _instance = value; }
        }

        private DiBase()
        {
        }


        public static void Init()
        {
            if (Instance == null)
            {
                Instance = new DiBase();
            }
        }
        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            Container.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            Container.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            Container.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
