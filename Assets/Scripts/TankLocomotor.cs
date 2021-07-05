using UnityEngine;

public class TankLocomotor : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Direction.x * Speed, 0, Direction.z * Speed);
        //Debug.Log($"FixedUpdate {rb.velocity}");

    }

    static public Vector3 GetDirectionWithRotation(Transform transform)
    {
        return transform.rotation * Vector3.forward;
    }
}
