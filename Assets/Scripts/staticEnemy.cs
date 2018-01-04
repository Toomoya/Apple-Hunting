using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticEnemy : MonoBehaviour {
	Animator animator;

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player"){ //&& (col.gameObject.GetComponent<MaxController> ().isAttacking == true)) {
			Rigidbody rb = this.gameObject.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3 (10, 10, 10);
			rb.useGravity = false;
			Destroy (this.gameObject, 2.0f);

		}
	}
}