using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventEnum
{
    ON_RUNR = 0,
    ON_RUNL = 1,
    ON_MOVER = 2,
    ON_MOVEL = 3,
    ON_SHOOT = 4,
    ON_IDLE = 5,
    ON_EPDEAD = 6,
    ON_SPAWN_COMPLETE = 7
}

public static class EventManager
{
    private static Dictionary<EventEnum, System.Action> eventDictionary = new Dictionary<EventEnum, System.Action>();

    public static void SubscribeToEvent(EventEnum eventType, System.Action function)
    {
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary.Add(eventType, null);
        }
        eventDictionary[eventType] += function;
        //Debug.Log("EventSubscribed");
    }
    public static void RemoveListener(EventEnum eventType, System.Action function)
    {
        if (eventDictionary.ContainsKey(eventType) && eventDictionary[eventType] != null)
        {
            eventDictionary[eventType] -= function;
            //Debug.Log("EventRemoved");
        }
    }
    public static void RaiseEvent(EventEnum eventType)
    {
        if (eventDictionary.ContainsKey(eventType) && eventDictionary[eventType] != null)
        {
            eventDictionary[eventType].Invoke();
            //Debug.Log("EventRaised");
        }
    }
}
