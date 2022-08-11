using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public EventSO eventSO;
    public EventSO pickupEventSO;
    public Image icon;

    private void Start()
    {
        eventSO.Occurred(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupEventSO.Occurred(gameObject);
        }
    }
}
