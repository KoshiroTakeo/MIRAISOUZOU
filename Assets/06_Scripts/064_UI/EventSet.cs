using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventSet : MonoBehaviour
{
    public UnityEvent initEvent;

    void Start()
    {
        initEvent.Invoke();
    }
    public void Event1(String str)
    {
        Debug.Log("Event1ÅF" + str);
    }
}
