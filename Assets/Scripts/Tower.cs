using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private float current_angle = 0f;
    private Quaternion startRotation;
    private float min = -35f;
    private float max = 35f;

    private void Start()
    {
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        current_angle += Input.GetAxis("Mouse X");
        current_angle = Mathf.Clamp(current_angle, min, max);
        Quaternion newRotation = Quaternion.AngleAxis(current_angle, new Vector3(0, 1, 0));
        transform.localRotation = startRotation * newRotation;

    }
}
