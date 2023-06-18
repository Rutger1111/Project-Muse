using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignValue : MonoBehaviour
{
    [SerializeField] private int objectValue;
    [SerializeField] private GameObject scenarioSystem;
    [SerializeField] private InvisibleSlider invisibleSlider;
    private void Awake()
    {
        invisibleSlider = scenarioSystem.GetComponent<InvisibleSlider>();
    }

    public void AddValue()
    {
        invisibleSlider.CheckValue(objectValue);
    }
}
