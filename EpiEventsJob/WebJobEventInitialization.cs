using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Events;
using EPiServer.Events.Clients;
using EPiServer.Events.Clients.Internal;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace ConsoleSdkJob
{
    [InitializableModule]
    [ModuleDependency(typeof(EventsInitialization))]
    public class WebJobEventInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            Console.WriteLine("Initialization module Initialize");
            var events = Event.GetAll();
            foreach (var ev in events)
            {
                Console.WriteLine($"Subscribing on {ev.Id}");
                ev.Raised+= HandleEvent;
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            var events = Event.GetAll();
            foreach (var ev in events)
            {
                Console.WriteLine($"Unsubscribing from {ev.Id}");
                ev.Raised -= HandleEvent;
            }
        }
        private static void HandleEvent(object sender, EventNotificationEventArgs e)
        {
            Console.WriteLine($"Raised event: {e.EventId} {e.Param}");
        }
    }
}
