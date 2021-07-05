using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioClip HealSound;
    public GameObject HealEffect;
    public float HealTimeFrames = 60f;

    //private Rigidbody rb;
    //private Renderer render;
    private AudioSource sound;
    private Vector3 startScale;

    private IEnumerator colorCoroutine;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //render = GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
    }

    public void Impact()
    {
        if (colorCoroutine != null) return;

        startScale = transform.localScale;
        transform.localScale = new Vector3();
        //render.material.color = new Color(255, 255, 255);

        colorCoroutine = SetupHeal();
        StartCoroutine(colorCoroutine);
    }

    private IEnumerator SetupHeal()
    {
        for (int i = 0; i < HealTimeFrames; i++)
        {
            //Debug.Log("Tick");
            //byte progressColor = (byte)((/*1*/ - i / HealTimeFrames) * 255);
            //render.material.color. = (float)i / HealTimeFrames;//new Color(progressColor, progressColor, progressColor);
            transform.localScale = startScale * (i / HealTimeFrames);
            yield return null;
        }
        HealingDone();
        colorCoroutine = null;
    }

    private void HealingDone()
    {
        sound.PlayOneShot(HealSound);
        Instantiate(HealEffect).transform.position = transform.position;
    }
}
