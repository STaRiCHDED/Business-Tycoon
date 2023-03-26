using SimpleEventBus;
using SimpleEventBus.Interfaces;

namespace Events
{
    public class EventStreams
    {
        public static IEventBus Game { get; } = new EventBus();
    }
}
