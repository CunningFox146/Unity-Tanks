using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TankSoundPlayer : MonoBehaviour
{
    private AudioSource sound;
    public float Volume { get => sound.volume; set => sound.volume = value; }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
}


