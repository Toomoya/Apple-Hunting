using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour {
	
	public int jumpPower=15;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player"){
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (0, jumpPower, 0);
		}

	}

}

