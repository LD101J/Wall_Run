using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gravity_UI : MonoBehaviour
{
    //[SerializeField] private Slider slider;

    [HideInInspector]
    public Player character;
    [SerializeField] Image meter_Image;
    [SerializeField] Text hp_Text;
    [SerializeField]float max_Hit_Points = 100f;
    public float decrementValue = 0.01f; // You can change this value based on your needs
    //[SerializeField] private Hit_Points hit_Points;

    private void Start()
    {
        meter_Image.fillAmount = max_Hit_Points;
    }
    private void Update()
    {
        Gravity_Bar();
    }

    private void Gravity_Bar()
    {
        
        meter_Image.fillAmount -= decrementValue;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
