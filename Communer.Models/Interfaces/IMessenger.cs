namespace Communer.Core.Models.Interfaces
{
    public interface IMessenger { }
    public interface IMessenger<T> : IMessenger
    {
        void Handle(T obj);
    }
    public interface IMessagingCenter
    {
        void Subscribe(IMessenger model);
        void Unsubscribe(IMessenger model);
        void Publish<T>(T message);
    }
}
