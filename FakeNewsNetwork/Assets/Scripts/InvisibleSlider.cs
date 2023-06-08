using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class InvisibleSlider : MonoBehaviour
{
    [SerializeField] private int sliderValue;
    private void OnGUI()
    {
        sliderValue = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(), sliderValue, 0, 20));
        //sliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), sliderValue, 0.0f, 20f);
    }
}
