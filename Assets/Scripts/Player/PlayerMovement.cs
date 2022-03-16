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
    private float jumpforce;
    [SerializeField]
    private float gravity;
    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnHorizontalAxis += OnHorizontalMove;
        playerInput.OnVerticalAxis += OnVerticalMove;

    }

    // Update is called once per frame
    void Update()
    {
        charController.Move(transform.forward * verticalMovementDelta*speed * Time.deltaTime);
        charController.Move(transform.right * horizontalMovementDelta*speed * Time.deltaTime);
        if (!charController.isGrounded)
        {
            charController.Move(Vector3.down*gravity*Time.deltaTime);
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
        if (charController.isGrounded) charController.Move(Vector3.up * jumpforce*Time.deltaTime);
    }
}
