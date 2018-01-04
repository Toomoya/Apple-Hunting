using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : MonoBehaviour {

	Animation anim;

	bool isAnim=true;
	void Start () {
		anim = this.gameObject.GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (isAnim == true) {
			Animation ();
		}
	}
	void Animation(){
		anim.Play ("Howl");

	}

}
