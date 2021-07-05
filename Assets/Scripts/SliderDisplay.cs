using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplay : MonoBehaviour
{
    public Slider slider;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = slider.value.ToString();
    }
}
