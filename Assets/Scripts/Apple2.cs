using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple2 : MonoBehaviour {

	public float speed =1.0f;
	//public GameObject shotman;
	void Start(){
//		Vector3 force;
//		force = this.gameObject.transform.forward * speed;
//		GetComponent<Rigidbody>().AddForce (force);


	}
	void Update(){
		this.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		Destroy (this.gameObject, 0.6f);
	}

}
