using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMove2D : MonoBehaviour
{
    [Header("MoveParameters")]
    [SerializeField] [Min(0)] float moveSpd_;
    [SerializeField] [Min(0)] float jumpForce_;

    [Header("InSkyDetection")]
    [SerializeField] Transform jumpOverlapPoint_;
    [SerializeField] Vector2 jumpOverlapSize_;
    [SerializeField] LayerMask jumpMask_;

    Rigidbody2D selfRigid2D_;

    float moveAxis_ = 0;

    bool inSky_ = false;

    Coroutine reverseAndWaitResetPlatformIE_ = null;

    const float POSITIVE_PLATFORM_EFFECTOR_ANGLE = 0;
    const float NEGATIVE_PLATFORM_EFFECTOR_ANGLE = 180;
    const float RESET_PLATFORM_EFFECTOR_OFFSET = 2;

    readonly Vector3 ORIGIN_ROT = Vector3.zero;
    readonly Vector3 FLIP_ROT = new(0, 180, 0);

    void Start()
    {
        selfRigid2D_ = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inSky_ = !Physics2D.OverlapBox(jumpOverlapPoint_.position, jumpOverlapSize_, jumpOverlapPoint_.eulerAngles.z, jumpMask_);

        selfRigid2D_.velocity = moveAxis_ * moveSpd_ * transform.right + selfRigid2D_.velocity.y * Vector3.up;
    }

    public void MoveInput(InputAction.CallbackContext callbackContext_)
    {
        moveAxis_ = callbackContext_.ReadValue<float>();

        if (moveAxis_ > 0)
        {
            transform.eulerAngles = ORIGIN_ROT;
        }
        if (moveAxis_ < 0)
        {
            transform.eulerAngles = FLIP_ROT;
        }
    }
    public void JumpInput(InputAction.CallbackContext callbackContext_)
    {
        if (callbackContext_.performed && !inSky_)
        {
            selfRigid2D_.AddForce(Vector2.up * jumpForce_);
        }
    }
    public void DownInput(InputAction.CallbackContext callbackContext_)
    {
        if (callbackContext_.performed && !inSky_)
        {
            RaycastHit2D raycastHit2D_ = Physics2D.Raycast(jumpOverlapPoint_.position, Vector2.down);
            PlatformEffector2D getPlatformEffector2D_ = raycastHit2D_.collider.GetComponent<PlatformEffector2D>();
            if (getPlatformEffector2D_ != null && reverseAndWaitResetPlatformIE_ == null)
            {
                reverseAndWaitResetPlatformIE_ = StartCoroutine(reverseAndWaitResetPlatform(getPlatformEffector2D_));
            }
        }
    }
    IEnumerator reverseAndWaitResetPlatform(PlatformEffector2D platformEffector2D_)
    {
        float startPosY_ = transform.position.y;
        platformEffector2D_.rotationalOffset = NEGATIVE_PLATFORM_EFFECTOR_ANGLE;
        while(transform.position.y > startPosY_ - RESET_PLATFORM_EFFECTOR_OFFSET)
        {
            yield return new WaitUpdateAndNotPause();
        }
        platformEffector2D_.rotationalOffset = POSITIVE_PLATFORM_EFFECTOR_ANGLE;

        reverseAndWaitResetPlatformIE_ = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.matrix = Matrix4x4.TRS(jumpOverlapPoint_.position, jumpOverlapPoint_.rotation, jumpOverlapSize_);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }
}


