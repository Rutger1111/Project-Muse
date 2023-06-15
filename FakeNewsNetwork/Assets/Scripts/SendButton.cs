using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SendButton : MonoBehaviour
{
	private bool sending = false;
	private Vector3 moveOfScreen = new Vector3(100, 0, 0);
	private GameObject article;
	void Start()
	{
		Button btn = GameObject.Find("SendButton").GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		article = GameObject.Find("Article");
		Debug.Log(article.transform.position);
	}
    private void Update()
    {
        if (sending == true)
        {
			if (GetComponent<Renderer>().isVisible)
			{
				transform.position += moveOfScreen * Time.deltaTime;
			}
            else
            {
				transform.position = new Vector3(0, 150, 135);
				sending = false;
            }
		}
    }

    void TaskOnClick()
	{
		sending = true;
	}
}
