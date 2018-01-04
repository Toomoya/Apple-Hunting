using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") == true) {
			SceneManager.LoadScene ("Menu");
		}
	}
	public void StartButton(){
		SceneManager.LoadScene ("Menu");
	}
}
