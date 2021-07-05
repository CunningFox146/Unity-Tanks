using UnityEngine;

class PlayerController : MonoBehaviour
{
    public float RotationSpeed = 50f;

    private TankLocomotor locomotor;

    void Start()
    {
        locomotor = GetComponent<TankLocomotor>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //locomotor.Direction = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Rotate(0f, moveHorizontal * RotationSpeed, 0f);
        locomotor.Direction = transform.rotation * Vector3.forward * moveVertical;
    }
}
