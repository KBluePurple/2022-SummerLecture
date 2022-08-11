using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSO", menuName = "GameEvent")]
public class EventSO : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void Register(EventListener listener)
    {
        listeners.Add(listener);
    }

    public void Unregister(EventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Occurred(GameObject obj)
    {
        foreach (var listener in listeners)
        {
            listener.OnEventOccurred(obj);
        }
    }
}