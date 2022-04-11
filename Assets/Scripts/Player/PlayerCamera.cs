using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private float sensability;
    [SerializeField]
    private float maxDistanceReach;
    [SerializeField]
    private Player player;
    private Quaternion zRotation;
    private Quaternion xRotation;
    public float minAxesXRotation = -90f;
    public float maxAxesXRotation = 90f;
    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnHorizontalMouseAxis += RotateX;
        playerInput.OnVerticalMouseAxis += RotateY;
        xRotation = transform.localRotation;
        zRotation = player.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
     //   Quaternion rotation = new Quaternion(xRotation.x, zRotation.y, 0, 1);
     //   transform.rotation = rotation;
    }
    public void RotateX(float mouse)
    {
        zRotation *= Quaternion.Euler(0f, mouse * sensability, 0f);
        player.gameObject.transform.rotation = zRotation;
    }
    public void RotateY(float mouse)
    {
        xRotation *= Quaternion.Euler(-mouse * sensability, 0, 0);
        xRotation = ClampRotationAroundXAxis(xRotation);
        transform.localRotation = xRotation;

    }
    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, minAxesXRotation, maxAxesXRotation);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
    public void InteractWithObject()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit raycast, maxDistanceReach);
        
        try
        {
        var interactable = raycast.transform.gameObject.GetComponent<IInteractable>() ?? raycast.transform.gameObject.GetComponentInParent<IInteractable>();
        player.Interact(interactable);
        }
        catch { Debug.Log("Not Interactable"); }
    }
    public void MeleeAttack() 
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit raycast, maxDistanceReach);

        try
        {
            var hitable = raycast.transform.gameObject.GetComponent<IHitable>() ?? raycast.transform.gameObject.GetComponentInParent<IHitable>();
            hitable.GetHit(player.meleeDamage);
        }
        catch { Debug.Log("Not Hitable"); }
    }
    
}
