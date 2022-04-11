using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private CharacterController charController;
    private float horizontalMovementDelta;
    private float verticalMovementDelta;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float crouchspeed;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private float gravity;
    
    private float realGravity;
    private static int WALKING_DIRECTION_X = Animator.StringToHash("HorizontalDirection");
    private static int WALKING_DIRECTION_Y = Animator.StringToHash("VerticalDirection");
    [SerializeField]
    private Animator animator;
    private float actualSpeed;
    private Coroutine jumpcoroutine;
    [SerializeField]
    private float jumptime;
    [SerializeField]
    private GameObject playersHead;
    [SerializeField]
    private float headHeightOnStay;
    [SerializeField]
    private float headHeightOnCrouch;
    
    void Start()
    {
        playerInput.OnHorizontalAxis += OnHorizontalMove;
        playerInput.OnVerticalAxis += OnVerticalMove;
        actualSpeed = speed;
        realGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        charController.Move(transform.forward * verticalMovementDelta*actualSpeed * Time.deltaTime);
        charController.Move(transform.right * horizontalMovementDelta*actualSpeed * Time.deltaTime);
        animator.SetFloat(WALKING_DIRECTION_X, horizontalMovementDelta);
        animator.SetFloat(WALKING_DIRECTION_Y, verticalMovementDelta);

        if (!charController.isGrounded)
        {
            charController.Move(Vector3.down*realGravity*Time.deltaTime);
        }
    }
    private void OnHorizontalMove(float horizontalDelta)
    {
        horizontalMovementDelta = horizontalDelta;
    }
    private void OnVerticalMove(float verticalDelta)
    {
        verticalMovementDelta=verticalDelta;
    }
    public void Jump()
    {
        if (charController.isGrounded)
        {
            realGravity = -jumpforce;
            jumpcoroutine = StartCoroutine("JumpingCoroutine");
        }
    }
    private IEnumerator JumpingCoroutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(jumptime);
            realGravity = gravity;
            StopCoroutine(jumpcoroutine);
            
        }
    }
    public void SetCrouch() 
    {
        if (!animator.GetBool("IsCrouching"))
        {
            actualSpeed = crouchspeed;
            animator.SetBool("IsCrouching", true);
            playersHead.transform.localPosition = new Vector3(0, headHeightOnCrouch, 0);
        }
        else 
        {
            actualSpeed = speed;
            animator.SetBool("IsCrouching", false);
            playersHead.transform.localPosition = new Vector3(0, headHeightOnStay, 0);
        }
    }
}
