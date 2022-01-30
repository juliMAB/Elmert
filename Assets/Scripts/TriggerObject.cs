using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public Action action = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        action.Invoke();
    }
}
