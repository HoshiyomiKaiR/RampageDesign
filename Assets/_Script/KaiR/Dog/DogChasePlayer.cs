using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DogChasePlayer : MonoBehaviour
{
    [SerializeField] Transform playerTrans_;

    [Header("UnityEvent")]
    [SerializeField] UnityEvent dashEvent_;

    [Header("MoveParameters")]
    [SerializeField] float moveSpd_;

    [Header("TimeValues")]
    [SerializeField] float normalChaseTime_;
    [SerializeField] float fastChaseTime_;

    Rigidbody2D selfRigid2D_;

    readonly Vector3 ORIGIN_ROT = new(0, 180, 0);
    readonly Vector3 FLIP_ROT = Vector3.zero;

    void Start()
    {
        selfRigid2D_ = GetComponent<Rigidbody2D>();
    }

    public void StartChase()
    {
        StartCoroutine(nameof(chasePlayer));
    }
    public void StopChase()
    {
        StopCoroutine(nameof(chasePlayer));
    }
    IEnumerator chasePlayer()
    {
        float duration_ = 0;
        while (duration_ < normalChaseTime_)
        {
            if (playerTrans_.position.x < transform.position.x)
            {
                transform.eulerAngles = FLIP_ROT;
            }
            if(playerTrans_.position.x > transform.position.x)
            {
                transform.eulerAngles = ORIGIN_ROT;
            }

            selfRigid2D_.velocity = moveSpd_ * -transform.right;

            duration_ += Time.deltaTime;
            yield return new WaitUpdateAndNotPause();
        }

        float distance_ = Vector2.Distance(transform.position, playerTrans_.position);
        float dashSpd_ = distance_ / fastChaseTime_;
        dashEvent_.Invoke();
        while (true)
        {
            if (playerTrans_.position.x < transform.position.x)
            {
                transform.eulerAngles = FLIP_ROT;
            }
            if (playerTrans_.position.x > transform.position.x)
            {
                transform.eulerAngles = ORIGIN_ROT;
            }

            selfRigid2D_.velocity = dashSpd_ * -transform.right;
            yield return new WaitUpdateAndNotPause();
        }
    }
}
