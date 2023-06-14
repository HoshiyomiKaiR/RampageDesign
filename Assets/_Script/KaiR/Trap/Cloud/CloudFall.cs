using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFall : MonoBehaviour
{
    [SerializeField] float spd_;
    [SerializeField] float stopPointOffset_;
    [SerializeField] LayerMask groundMask_;

    Collider2D selfCollider2D_;
    SpriteRenderer selfSpriteRenderer_;

    void Start()
    {
        selfCollider2D_ = GetComponent<Collider2D>();
        selfSpriteRenderer_ = GetComponent<SpriteRenderer>();
    }

    public void StartFall()
    {
        StartCoroutine(nameof(fallToGround));
    }
    IEnumerator fallToGround()
    {
        RaycastHit2D raycastHit2D_ = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, groundMask_);
        float stopPoint_ = raycastHit2D_.point.y + stopPointOffset_;
        while (transform.position.y > stopPoint_)
        {
            transform.Translate(spd_ * Time.deltaTime * Vector2.down);
            yield return new WaitUpdateAndNotPause();
        }
        selfCollider2D_.enabled = false;
        selfSpriteRenderer_.enabled = false;

    }
}
