using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//GetComponent<BoxCollider> ().enabled = false;
		Destroy (this.gameObject, 0.2f);
	}
}
