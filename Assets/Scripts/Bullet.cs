using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;
    public float CurrentMoveSpeed = 50f;
    public GameObject Launcher;
    public bool IsPlayer = false;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up * CurrentMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((IsPlayer && other.CompareTag("Player")) || (!IsPlayer && other.CompareTag("Enemy")) || other.CompareTag("BulletIgnore")) return;

        var explosion = Instantiate(Explosion);
        explosion.GetComponent<Explosion>().SetTarget(other.gameObject);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}
