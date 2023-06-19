using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextClickable : MonoBehaviour
{
    public TextMeshPro textmeshpro;
    public SpriteRenderer image;
    public List<string> titles;
    public List<Sprite> pictures;
    public int whatTitles;
    public int whatTitle;
    public int whatImage;
    private RaycastHit hit;
    public LayerMask layermask;
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
    public void sended()
    {
        whatTitle = 0;
        whatTitles += 2;
        if (whatTitle >= 6)
        {
            whatTitle -= 1;
        }
        title2.GetComponent<TextMesh>().text = titles[whatTitle + 1];
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {
            print(whatTitle + "werkt");
            if (hit.collider.tag == "Title2" && (hit.collider.tag == "Title2" && whatTitle == whatTitles))
            {
                whatTitle = 1;
                print("werkt" + textmeshpro.text);
                textmeshpro.text = titles[whatTitles + whatTitle];

                print("werkt" + hit.collider.GetComponent<TextMeshPro>().text);
            }
            else if (hit.collider.tag == "Title2" && (hit.collider.tag == "Title2" && whatTitle == whatTitles + 1))
            {
                print(textmeshpro.text);
                textmeshpro.text = titles[whatTitles];
                whatTitle = 0;
                print("werkt" + textmeshpro.text);
            }
        }
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {
            print(whatTitle + "werkt");
            if (hit.collider.tag == "Image2" && (hit.collider.tag == "Image2" && whatImage == whatTitles))
            {
                whatImage = 1;
                print("werkt" + image.sprite);
                image.sprite = pictures[whatTitles + whatImage];
                print("werkt" + image.sprite);
            }
            else if (hit.collider.tag == "Image2" && (hit.collider.tag == "Image2" && whatImage == whatTitles + 1))
            {
                whatImage = 0;
                print(image.sprite);
                image.sprite = pictures[whatTitles + whatImage];
                print("werkt" + image.sprite);
            }
        }
        
    }
}
