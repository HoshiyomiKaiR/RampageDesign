using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] Sprite changeSprite_;

    SpriteRenderer selfSpriteRenderer_;

    void Start()
    {
        selfSpriteRenderer_ = GetComponent<SpriteRenderer>();
    }

    public void Change()
    {
        selfSpriteRenderer_.sprite = changeSprite_;
    }
}
