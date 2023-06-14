using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeBoundingShape : MonoBehaviour
{
    [SerializeField] CompositeCollider2D changeCompositeCollider2D_;

    CinemachineConfiner2D selfCinemachineConfiner2D_;

    void Start()
    {
        selfCinemachineConfiner2D_ = GetComponent<CinemachineConfiner2D>();
    }

    public void Change()
    {
        selfCinemachineConfiner2D_.m_BoundingShape2D = changeCompositeCollider2D_;
    }
}
