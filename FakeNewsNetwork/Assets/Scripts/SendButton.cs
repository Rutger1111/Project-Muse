using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SendButton : MonoBehaviour
{
	private GameObject article;
	void Start()
	{
		Button btn = GameObject.Find("SendButton").GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		article = GameObject.Find("Article");
		Debug.Log(article.transform.position);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		article.transform.position = new Vector2(10,0);
	}
}
