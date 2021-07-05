using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEyesight : MonoBehaviour
{
    public Bot BotTank;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        BotTank.SetTarget(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && BotTank.Target == other.gameObject)
            BotTank.SetTarget(null);
    }
}
