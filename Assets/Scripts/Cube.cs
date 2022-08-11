using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f;
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * _speed * Time.deltaTime);
    }
}
