using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletMoveSpeed = 50f;
    public bool IsPlayer = false;

    private float current_angle = 0f;
    private Quaternion startRotation;
    private float min = -20f;
    private float max = 45f;

    private void Start()
    {
        startRotation = transform.localRotation;
    }

    public void Shoot(GameObject target)
    {
        Vector3 forwardPos = transform.position + transform.TransformDirection(Vector3.up * 1f);
        forwardPos.y -= 1;
        var bullet = Instantiate(Bullet, forwardPos, transform.rotation);
        var bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.CurrentMoveSpeed = BulletMoveSpeed;
        bulletComponent.Launcher = gameObject;
        bullet.transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlayer) return;

        current_angle += Input.GetAxis("Mouse Y");
        current_angle = Mathf.Clamp(current_angle, min, max);
        Quaternion newRotation = Quaternion.AngleAxis(current_angle, new Vector3(-1, 0, 0));
        transform.localRotation = startRotation * newRotation;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(null);
        }
    }

    public void OnSpeedChanged(float value)
    {
        BulletMoveSpeed = value;
    }
}
