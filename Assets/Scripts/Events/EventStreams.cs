using SimpleEventBus;
using SimpleEventBus.Events;
using SimpleEventBus.Interfaces;

namespace Events
{
    public class EventStreams
    {
        public static IEventBus Game { get; } = new EventBus();
    }

    public class SaveGameEvent : EventBase
    {
        public SaveGameEvent()
        {
            
        }
    }
}
