using UnityEngine;

public class Bot : MonoBehaviour
{
    public float RotationSpeed;
    public Vector3 Direction;
    public GameObject Target;
    public float AttackCd = 3f;
    public Canon canon;

    private Rigidbody rb;
    private TankLocomotor locomotor;

    private float shootCd = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        locomotor = GetComponent<TankLocomotor>();

        GameManager.Inst.AddTarget(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.Inst.RemoveTarget(gameObject);
    }

    public void SetTarget(GameObject target)
    {
        if (target != null)
        {
            Target = target;
        }
        else
        {
            Target = null;
            locomotor.Direction = Vector3.zero;
        }
               
    }

    public void Update()
    {
        if (Target == null) return;
        var pos = Target.transform.position;

        Vector3 targetDir = Target.transform.position - transform.position;
        targetDir.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * RotationSpeed);

        float distance = Vector3.Distance(pos, transform.position);

        if (distance > 20)
        {
            locomotor.Direction = TankLocomotor.GetDirectionWithRotation(transform);
        }
        else
        {
            locomotor.Direction = Vector3.zero;

            shootCd += Time.deltaTime;
            if (shootCd >= AttackCd)
            {
                shootCd = 0;

                canon.Shoot(Target);
            }
        }

        
        //transform.position = Vector3.Lerp(transform.position, other.transform.position, Time.deltaTime * moveSpeed);
    }
}
