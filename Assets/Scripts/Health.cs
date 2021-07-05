using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth = 10f;
    public bool IsPlayer;

    public void OnHit()
    {
        --CurrentHealth;

        if (CurrentHealth <= 0)
        {
            if (IsPlayer)
            {
                GameManager.Inst.EndGame(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
