using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("GAME OVER");
			GameObject.Find ("MAX").GetComponent<MaxController> ().appleCount = 0;
			SceneManager.LoadScene ("ClearScene");
		}
	}
}
