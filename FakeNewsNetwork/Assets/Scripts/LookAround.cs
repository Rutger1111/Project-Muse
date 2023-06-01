using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private bool _canLookAround = false;
    [SerializeField] private EnvirementInteraction envInteract;

    // Update is called once per frame
    void Update()
    {
        if (envInteract._isZoomedIn == false)
        {
            CanRotateCheck();
        }
    }

    public void CanRotateCheck()
    {
        var result = (Input.mousePosition.x < Screen.width / 2 && Input.GetKey(KeyCode.Mouse1) || Input.mousePosition.x > Screen.width / 2 && Input.GetKey(KeyCode.Mouse1)) ? ((Input.mousePosition.x >= Screen.width / 2) ? (-25) : 25) :  (0);
        lookAround(result);
    }

    public void lookAround(float rotationSpeed)
    {
        var afloat = Camera.main.transform.eulerAngles.y;
        if (Camera.main.transform.eulerAngles.y >= 340 || Camera.main.transform.eulerAngles.y <= 20)
        {
            Camera.main.transform.eulerAngles -= new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        }

        var rotationY = (Camera.main.transform.eulerAngles.y !>= 340 || Camera.main.transform.eulerAngles.y !<= 20) ? (Camera.main.transform.eulerAngles.y) : (Camera.main.transform.eulerAngles.y <= 340 && Camera.main.transform.eulerAngles.y >= 160 ? 340.1f : 19.9f);
        Camera.main.transform.eulerAngles = new Vector3 (Camera.main.transform.eulerAngles.x, rotationY, Camera.main.transform.eulerAngles.z);
    }
}
