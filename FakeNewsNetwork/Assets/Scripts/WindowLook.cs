using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowLook : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent = new UnityEvent();

    [SerializeField] private GameObject OfficeCamera;
    [SerializeField] private GameObject WindowCamera;
    private void Start()
    {
        unityEvent.Invoke();
    }

    public void WindowLookf()
    {
        if (OfficeCamera.activeSelf == true)
        {
            WindowCamera.SetActive(true);
            OfficeCamera.SetActive(false);
        }
        else
        {
            WindowCamera.SetActive(false);
            OfficeCamera.SetActive(true);
        }
    }
}
