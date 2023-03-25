using SimpleEventBus;
using SimpleEventBus.Interfaces;

public class EventStreams
{
    public static IEventBus Game { get; } = new EventBus();
}
