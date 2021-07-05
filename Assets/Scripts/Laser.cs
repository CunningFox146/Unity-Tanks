using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Debug.Log("Found");
            if (hit.collider && !hit.collider.CompareTag("BulletIgnore"))
            {
                line.SetPosition(1, hit.point);
            }
        }
        else
        {
            Debug.Log("Not found");
            line.SetPosition(1, transform.forward * 5000);
        }

    }
}
