using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void AxisHandler(float axisValue);

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private PlayerCamera playerCamera;
    [SerializeField]
    private PlayerMovement playerMovement;
    public event AxisHandler OnHorizontalAxis;
    public event AxisHandler OnVerticalAxis;
    public event AxisHandler OnVerticalMouseAxis;
    public event AxisHandler OnHorizontalMouseAxis;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnHorizontalAxis?.Invoke(Input.GetAxis("Horizontal"));
        OnVerticalAxis?.Invoke(Input.GetAxis("Vertical"));
        OnHorizontalMouseAxis?.Invoke(Input.GetAxis("Mouse X"));
        OnVerticalMouseAxis?.Invoke(Input.GetAxis("Mouse Y"));
        if (Input.GetButtonDown("Interact")) playerCamera.InteractWithObject();
        if (Input.GetButtonDown("Fire1")) player.currentGun.Shoot();
        
        if (Input.GetButton("Jump")) playerMovement.Jump();
    }
    
}
