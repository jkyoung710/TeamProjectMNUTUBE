using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainEventBus : MonoBehaviour
{
    static readonly IDictionary<MainEventType, UnityEvent> CameraModeEvents = new Dictionary<MainEventType, UnityEvent>();

    public static void Subscribe(MainEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (CameraModeEvents.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            CameraModeEvents.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe(MainEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (CameraModeEvents.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(MainEventType eventType)
    {
        UnityEvent thisEvent;

        if (CameraModeEvents.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
