using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLiftOff : MonoBehaviour
{
    [SerializeField] float spd_;

    void Update()
    {
        transform.Translate(spd_ * Time.deltaTime * Vector2.up);
    }
}
