using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gravity_UI : MonoBehaviour
{
    [SerializeField] private Slider slider;
  
    public void Set_Max_Health(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void Set_Health(int health)
    {
        slider.value = health;
    }
}
