using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResetCountdown : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        var time = GameManager.Inst.TimeBeforeReset;
        if (time >= 0f)
        {
            text.text = $"Перезапуск через {(int)time}";
        }
    }
}
