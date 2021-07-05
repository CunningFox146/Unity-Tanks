using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PannelMover : MonoBehaviour
{
    enum PannelStates
    {
        Closed,
        Open,
        Closing,
        Opening,
    }

    public Text ButtonText;
    public GameObject UIGameObject;
    public float MoveX = 100f;
    public float Speed = 3;

    private float currentX = 0f;
    private PannelStates state = PannelStates.Open;

    public void MovePanel()
    {
        if (state == PannelStates.Closing || state == PannelStates.Opening) return;
        bool closed = state == PannelStates.Closed;
        var pos = UIGameObject.transform.position;

        currentX = 0;

        state = closed ? PannelStates.Opening : PannelStates.Closing;
        ButtonText.text = closed ? "Закрыть" : "Открыть";
    }

    private void Update()
    {
        if (state == PannelStates.Closed || state == PannelStates.Open) return;

        bool closing = state == PannelStates.Closing;
        var pos = UIGameObject.transform.position;

        currentX = Mathf.Min(currentX + Time.deltaTime * Speed, MoveX);
        UIGameObject.transform.position = new Vector2(pos.x + currentX * (closing ? 1 : -1), pos.y);
        Debug.Log(currentX);
        if (currentX >= MoveX || currentX <= 0)
        {
            state = closing ? PannelStates.Closed : PannelStates.Open;
        }
    }
}
