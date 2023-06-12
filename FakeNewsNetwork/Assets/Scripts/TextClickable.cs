using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClickable : MonoBehaviour
{
    private RaycastHit hit;

    [Header("Title")]
    public GameObject title1;
    public GameObject title2;

    [Header("Image")]
    public GameObject image1;
    public GameObject image2;

    [Header("Lists")]
    public string[] titlesList;


    // Start is called before the first frame update
    void Start()
    {
        title1 = GameObject.FindGameObjectWithTag("Title1");
        title2 = GameObject.FindGameObjectWithTag("Title2");
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.point.x >= -40 && hit.point.x <= 30 && hit.point.y >= 35 && hit.point.y <= 45 && this.gameObject.transform.position.y <= 5)
            {
                Vector3 tempPosition = title1.transform.position;
                title1.transform.position = title2.transform.position;
                title2.transform.position = tempPosition;
            }
        }
    }
}
