using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnvirementInteraction : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float positionSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private bool _isZooming = false;
    [SerializeField] private bool _isZoomingOut = false;
    [SerializeField] public bool _isZoomedIn = false;

    [SerializeField] private Vector3 cameraCloseInPosition;
    [SerializeField] private Vector3 cameraCloseOutPosition;

    [SerializeField] private Vector3 cameraCloseInLookRotation;
    public Vector3 cameraCloseOutLookRotation;

    [SerializeField] private Vector3 cameraCloseOutLookDirection;
    [SerializeField] private Vector3 cameraCloseOutDirection;

    [SerializeField] private Vector3 closeInDirection;
    [SerializeField] private Vector3 closeInLookDirection;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*Mathf.Infinity);
        ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isZoomedIn == false)
        {
            Zoom(true);
        }
        if(_isZooming == true)
        {
            ZoomingIn();
        }
        if (_isZoomingOut == true && _isZoomedIn == true)
        {
            ZoomingOut();

        }
        if (Input.GetMouseButtonDown(1) && _isZooming == false && _isZoomedIn == true)
        {
            _isZoomingOut = true;
            ZoomingOut();
        }
    }
    public void AnimationStarting()
    {

    }
    public void ZoomingIn()
    {

        closeInDirection = Vector3.Normalize(Camera.main.transform.position - cameraCloseInPosition);
        closeInLookDirection = Vector3.Normalize(Camera.main.transform.eulerAngles - cameraCloseInLookRotation);
        Debug.Log(closeInDirection);
        Camera.main.transform.position -= (closeInDirection * positionSpeed) * Time.deltaTime;
        Camera.main.transform.eulerAngles -= (closeInLookDirection * rotationSpeed) * Time.deltaTime;
        if (Vector3.Distance(Camera.main.transform.position, cameraCloseInPosition) <= 0.007)
        {
            _isZooming = false;
            Camera.main.transform.position = cameraCloseInPosition;
            Camera.main.transform.eulerAngles = cameraCloseInLookRotation;
        }
    }
    public void ZoomingOut()
    {
        cameraCloseOutDirection = Vector3.Normalize(Camera.main.transform.position - cameraCloseOutPosition);
        cameraCloseOutLookDirection = Vector3.Normalize(Camera.main.transform.eulerAngles - cameraCloseOutLookRotation);
        Debug.Log(closeInDirection);
        Camera.main.transform.position -= (cameraCloseOutDirection * positionSpeed) * Time.deltaTime;
        Camera.main.transform.eulerAngles -= (cameraCloseOutLookDirection * rotationSpeed) * Time.deltaTime;
        if (Camera.main.transform.position.z < cameraCloseOutPosition.z)
        {
            _isZoomingOut = false;
            _isZoomedIn = false;
            Camera.main.transform.position = cameraCloseOutPosition;
            Camera.main.transform.eulerAngles = cameraCloseOutLookRotation;
        }
    }
    public void Zoom(bool zoomIn)
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "PC" && _isZooming == false)
            {
                _isZooming = true;
                _isZoomedIn = true;
                Debug.Log("did hit");
            }
        }
    }
}
