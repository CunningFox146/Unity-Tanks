using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private Vector3 start;
    void Start()
    {
        GameManager.Inst.OnGameEnd += OnGameEnd;

        start = transform.position;
        transform.position = new Vector2(5000, 0);
    }

    void OnGameEnd(bool won)
    {
        if (won)
        {
            transform.position = start;
            gameObject.SetActive(true);
        }
    }
}
