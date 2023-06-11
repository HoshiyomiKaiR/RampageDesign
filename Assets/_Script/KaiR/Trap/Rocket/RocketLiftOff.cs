using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLiftOff : MonoBehaviour
{
    [SerializeField] float spd_;
    [SerializeField] float delayTime_;

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

        while (true)
        {
            transform.Translate(spd_ * Time.deltaTime * Vector2.up);
            yield return new WaitUpdateAndNotPause();
        }
    }
}
