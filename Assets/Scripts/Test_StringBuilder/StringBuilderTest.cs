using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StringBuilderTest : MonoBehaviour
{
    private void Start()
    {
        StringDemo();
    }

    private void StringDemo()
    {
        string str = "Hello";
        StringBuilder sb = new StringBuilder();
        double startTime = DateTime.Now.TimeOfDay.TotalSeconds;

        for (int i = 0; i < 100000; i++)
        {
            sb.Append("str");
        }

        double endTime = DateTime.Now.TimeOfDay.TotalSeconds;
        Debug.Log($"{endTime - startTime}");

        str = "Hello";
        startTime = DateTime.Now.TimeOfDay.TotalSeconds;
        for (int i = 0; i < 100000; i++)
        {
            str += "str";
        }
        endTime = DateTime.Now.TimeOfDay.TotalSeconds;
        Debug.Log($"{endTime - startTime}");
    }
}
