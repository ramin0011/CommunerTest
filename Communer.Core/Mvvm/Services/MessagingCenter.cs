using System.Collections.Generic;
using System.Linq;
using Communer.Core.Models.Interfaces;

namespace Communer.Core.Mvvm.Services
{
    public class MessagingCenter : IMessagingCenter
    {
        private static List<IMessenger> subscribers = new List<IMessenger>();

        public void Subscribe(IMessenger model)
        {
            subscribers.Add(model);
        }

        public void Unsubscribe(IMessenger model)
        {
            subscribers.Remove(model);
        }

        public void Publish<T>(T message)
        {
            foreach (var item in subscribers.OfType<IMessenger<T>>())
            {
                item.Handle(message);
            }
        }
    }
}
