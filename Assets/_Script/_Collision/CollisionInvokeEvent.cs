using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionInvokeEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onCollisionEnterEvent_;
    [SerializeField] string validTag_;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(validTag_))
        {
            onCollisionEnterEvent_.Invoke();
        }
    }
}
