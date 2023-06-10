using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TiggerInvokeEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnterEvent_;
    [SerializeField] string validTag_;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(validTag_))
        {
            onTriggerEnterEvent_.Invoke();
        }
    }
}
