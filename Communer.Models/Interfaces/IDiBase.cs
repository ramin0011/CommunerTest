using System;

namespace Communer.Core.Models.Interfaces
{
    public interface IDiBase
    {
        T Resolve<T>();
        object Resolve(Type type);
        void Register<T>(T instance);
        void Register<TInterface, T>() where T : TInterface;
    }
}