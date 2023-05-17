using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private bool _canLookAround = false;

    public AnimationCurve animCurve;

    private float afloat;

    // Update is called once per frame
    void Update()
    {
        SpeedAdjust();
        //PlayerPrefs.SetString("_canLookSave", "CanLook");
        //string IsSaveved = PlayerPrefs.GetString("_canLookSave");
    }
    public void SpeedAdjust()
    {
        

        CanRotateCheck();
    }

    public void CanRotateCheck()
    {
        afloat = Camera.main.transform.eulerAngles.y;
        var result = (Input.mousePosition.x < Screen.width / 100 * 30 || Input.mousePosition.x > Screen.width / 100 * 70) ? ((Input.mousePosition.x > Screen.width / 100 * 70) ? (-50) : 50) :  (0);
        lookAround(result);
    }

    public void lookAround(float rotationSpeed)
    {
        
        if (Camera.main.transform.eulerAngles.y >= 340 || Camera.main.transform.eulerAngles.y <= 20)
        {
            Camera.main.transform.eulerAngles -= new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        }
        var rotationY = (Camera.main.transform.eulerAngles.y !>= 340 || Camera.main.transform.eulerAngles.y !<= 20) ? (Camera.main.transform.eulerAngles.y) : (Camera.main.transform.eulerAngles.y <= 340 && Camera.main.transform.eulerAngles.y >= 160 ? 340.1f : 19.9f);
        Camera.main.transform.eulerAngles = new Vector3 (Camera.main.transform.eulerAngles.x, rotationY, Camera.main.transform.eulerAngles.z);
        print(rotationSpeed);
    }
}
