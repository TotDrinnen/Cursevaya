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
    private bool inMenu;
    public void SetInMenu(bool value) { inMenu = value; }
    void Update()
    {
        if (player.isAlive&&!inMenu)
        {
            OnHorizontalAxis?.Invoke(Input.GetAxis("Horizontal"));
            OnVerticalAxis?.Invoke(Input.GetAxis("Vertical"));
            OnHorizontalMouseAxis?.Invoke(Input.GetAxis("Mouse X"));
            OnVerticalMouseAxis?.Invoke(Input.GetAxis("Mouse Y"));
            if (Input.GetButtonDown("Interact")) playerCamera.InteractWithObject();
            if (Input.GetButtonDown("Fire1"))
            {
                try {
                    player.currentGun.SetHold(true);
                    player.currentGun.Shoot(); }
                catch { player.MeleeAttack(); }
            }
            if (Input.GetButtonUp("Fire1")) player.currentGun.StopShootingCoroutine();
                if (Input.GetButtonDown("Jump")) playerMovement.Jump();
            if (Input.GetButtonDown("Crouch")) playerMovement.SetCrouch();
        }
    }
    
}
