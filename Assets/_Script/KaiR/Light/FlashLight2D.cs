using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight2D : MonoBehaviour
{
    [SerializeField] float maxIntensity_;
    [SerializeField] float flashTime_;

    float originIntensity_;
    float variation_;
    float duration_ = 0;

    Light2D selfLight2D_;

    void Start()
    {
        selfLight2D_ = GetComponent<Light2D>();

        originIntensity_ = selfLight2D_.intensity;
        variation_ = (maxIntensity_ - originIntensity_) / flashTime_;
    }

    void Update()
    {
        if (duration_ >= flashTime_)
        {
            duration_ = 0;
            selfLight2D_.intensity = originIntensity_;
        }

        selfLight2D_.intensity += variation_ * Time.deltaTime;

        duration_ += Time.deltaTime;
    }
}
