using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
	Vector3 initialPosition;
	Animation anim;
	AudioSource audioSource;

	public AudioClip FlyAway;

	 bool isAnim=true;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		anim = this.gameObject.GetComponent<Animation> ();
		audioSource = this.gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAnim == true) {
			Animation ();
		}

	}

	void Animation(){
		transform.position = new Vector3 (Mathf.Sin (Time.time) * 0.7f + initialPosition.x, initialPosition.y, initialPosition.z);
		anim.Play ("Walk");
		if (Mathf.Cos (Time.time) > 0) {
			this.transform.rotation = Quaternion.Euler (0, 90, 0);
		} else {
			this.transform.rotation = Quaternion.Euler (0, 270, 0);
		}
	}


	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "PlayerFoot"){ //&& (col.gameObject.GetComponent<MaxController> ().isAttacking == true)) {
			
			isAnim = false;
			Rigidbody rb = this.gameObject.GetComponent<Rigidbody> ();
			Destroy (anim);
			rb.velocity = new Vector3 (10, 10, 10);
			rb.useGravity = false;
			audioSource.clip = FlyAway;
			audioSource.Play ();
			Destroy (this.gameObject, 2.0f);

		}
	}
}

