using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour {

	public int speed;
	public int degree;
	bool isMove=true;
	AudioSource audioSource;
	public AudioClip FlyAway;
	// Use this for initialization
	void Start () {
		this.transform.rotation = Quaternion.Euler (0, degree, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMove == true) {
			Move ();
		} else {
			Fly ();
		}
	}
	void Move(){
		this.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		Destroy (this.gameObject, 3.0f);
	}
	void Fly(){
		this.transform.position += new Vector3 (0, 0.2f, 2*speed * Time.deltaTime);
		Destroy (this.gameObject, 3.0f);
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.GetComponent<MaxController> ().isAttacking == true) {
				isMove = false;
//				Debug.Log ("hit");
//				Rigidbody rb = this.gameObject.GetComponent<Rigidbody> ();
//				rb.velocity = new Vector3 (10, 10, 10);
//				Debug.Log ("hit2");
////				audioSource.clip = FlyAway;
////				audioSource.Play ();
//				rb.useGravity = false;
//				this.gameObject.GetComponent<BoxCollider> ().enabled = false;
//
//				Destroy (this.gameObject, 2.0f);
//			}
			}

		}

	}
}
