using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float CurrentMoveSpeed = 20f;
    public float RotationSpeed = 20f;
    public TankSoundPlayer SoundPlayer;

    private Rigidbody rb;
    private TankLocomotor locomotor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        locomotor = GetComponent<TankLocomotor>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundPlayer.Volume = (locomotor.Direction == Vector3.zero) ? 0 : 1;
    }

    public void OnSpeedChanged(float value)
    {
        locomotor.Speed = value;
    }
}
