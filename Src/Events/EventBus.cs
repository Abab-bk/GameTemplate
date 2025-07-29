using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Events;

public interface IEvent
{
}

public class EventBus
{
    private readonly Dictionary<Type, List<(object subscriber, Delegate handler)>> _handlers = new();
    private readonly object _lock = new();

    public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : struct, IEvent
    {
        var subscriber = handler.Target;
        if (subscriber == null) throw new ArgumentNullException(nameof(subscriber), "Subscriber cannot be null.");
        lock (_lock)
        {
            if (!_handlers.ContainsKey(typeof(TEvent)))
                _handlers.Add(typeof(TEvent), new List<(object subscriber, Delegate handler)>());
            _handlers[typeof(TEvent)].Add((subscriber, handler));
        }
    }

    public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : struct, IEvent
    {
        lock (_lock)
        {
            if (!_handlers.ContainsKey(typeof(TEvent))) return;
            _handlers[typeof(TEvent)].RemoveAll(entry => entry.handler.Equals(handler));

            if (!_handlers[typeof(TEvent)].Any()) _handlers.Remove(typeof(TEvent));
        }
    }

    public void UnsubscribeAll(object subscriber)
    {
        if (subscriber == null) throw new ArgumentNullException(nameof(subscriber), "Subscriber cannot be null.");

        lock (_lock)
        {
            foreach (var eventType in _handlers.Keys.ToList())
            {
                _handlers[eventType].RemoveAll(entry => ReferenceEquals(entry.subscriber, subscriber));

                if (!_handlers[eventType].Any()) _handlers.Remove(eventType);
            }
        }
    }

    public void Publish<TEvent>(TEvent eventData) where TEvent : struct, IEvent
    {
        List<(object subscriber, Delegate handler)> handlersToExecute;
        lock (_lock)
        {
            if (!_handlers.ContainsKey(typeof(TEvent))) return;
            handlersToExecute = [.._handlers[typeof(TEvent)]];
        }

        foreach (var entry in handlersToExecute) (entry.handler as Action<TEvent>)?.Invoke(eventData);
    }
}