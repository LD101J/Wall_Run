using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slider_Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slider_Text = null;
    [SerializeField] private float max_slider = 100f;

    public void Slider_Change(float value)
    {
        float localValue = value * max_slider;
        slider_Text.text = localValue.ToString("0");  
    }
}
