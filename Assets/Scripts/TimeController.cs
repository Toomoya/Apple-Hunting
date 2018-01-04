using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {
	

	float time;
	Text text;
	// Use this for initialization
	void Start () {
		time = 0;
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		int minute = (int)time / 60;
		int second = (int)time % 60;
		string minText, secText;
		if (minute < 10) {
			minText = "0" + minute.ToString ();
		} else {
			minText = minute.ToString ();
		}
		if (second < 10) {
			secText = "0" + second.ToString ();
		} else {
			secText = second.ToString ();
		}
		text.text = minText + ":" + secText;
	}
}
