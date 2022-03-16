using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastProjectile : MonoBehaviour,IPoolable
{   private float damage;
    
    public HitMarker hitMarker;
    public void RequestFromPool()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    public void setDamage(float damage) 
    {
        this.damage = damage;
    }
    public void Launch()
    {
        RequestFromPool();
        bool hit = Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit);
        if (hit) Hit(raycastHit);
    }
    public void Hit(RaycastHit hit)
    {
        var hitobject = hit.transform.gameObject.GetComponent<IHitable>() ?? hit.transform.gameObject.GetComponentInParent<IHitable>();
        hitobject.GetHit(damage);
        hitMarker.transform.position = hit.transform.position;
        hitMarker.gameObject.SetActive(true);
    }
}
