using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Force = 5f;
    public float Radius = 15f;
    
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void SetTarget(GameObject target)
    {
        //Debug.Log(target);
        var rb = target.GetComponent<Rigidbody>();
        var targetComponent = target.GetComponent<Target>();
        var health = target.GetComponent<Health>();

        if (rb)
            rb.AddExplosionForce(Force, transform.position, Radius, 0, ForceMode.VelocityChange);

        if (targetComponent)
            targetComponent.Impact();

        if (health)
        {
            health.OnHit();
        }
    }
}
