using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> {}

public class EventListener : MonoBehaviour
{
    public EventSO eventSO;

    public UnityGameObjectEvent responseObj = new ();

    private void OnEnable()
    {
        eventSO.Register(this);
    }

    private void OnDisable()
    {
        eventSO.Unregister(this);
    }

    public void OnEventOccurred(GameObject obj)
    {
        responseObj?.Invoke(obj);
    }
}
