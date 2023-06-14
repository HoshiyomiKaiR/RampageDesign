using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketLiftOff : MonoBehaviour
{
    [SerializeField] float spd_;
    [SerializeField] float delayTime_;
    [SerializeField] float moveTime_;

    public event EventHandler LiftOffEvent;

    public void StartLiftOff()
    {
        StartCoroutine(nameof(liftOff));
    }
    IEnumerator liftOff()
    {
        float waitDuration_ = 0;
        while (waitDuration_ < delayTime_)
        {
            waitDuration_ += Time.deltaTime;
            yield return new WaitUpdateAndNotPause();
        }

        float moveDuration_ = 0;
        while (moveDuration_ < moveTime_)
        {
            transform.Translate(spd_ * Time.deltaTime * Vector2.up);
            moveDuration_ += Time.deltaTime;
            yield return new WaitUpdateAndNotPause();
        }
        LiftOffEvent?.Invoke(this, EventArgs.Empty);
    }
}
