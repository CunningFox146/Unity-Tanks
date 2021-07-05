using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private GameManager manager;
    private Text textComponent;

    void Start()
    {
        manager = GameManager.Inst;
        textComponent = GetComponent<Text>();
    }

    void Update()
    {
        textComponent.text = (manager.GameDuration - manager.CurrentTime).ToString();
    }
}
