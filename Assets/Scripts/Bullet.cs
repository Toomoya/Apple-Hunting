using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed =300.0f;
	//public GameObject shotman;
	void Start(){
		Vector3 force;
		force = this.gameObject.transform.forward * speed;
		// Rigidbodyに力を加えて発射
		GetComponent<Rigidbody>().AddForce (force);
		// 弾丸の位置を調整
		//this.transform.position = shotman.transform.position;

	}
	void Update(){
		Destroy (this.gameObject, 1.0f);
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}


}
