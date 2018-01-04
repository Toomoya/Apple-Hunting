using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : MonoBehaviour {

	Animator animator;

	public GameObject bulletPrefab;
	public float speed = 7.0f;

	public float time = 0.0f;
	public float interval=2.7f;

	public float pojix;
	public float pojiy;
	public float pojiz;

	public float deg;

	private Vector3 pos;


	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= interval) {
			shoot ();
			time = 0.0f;
		}

	}

	void shoot(){
		//animator.SetBool ("isShot", true);
		GameObject bullet= Instantiate (bulletPrefab,new Vector3(pos.x+pojix ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) as GameObject;
	}
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}

//	void OnCollisionEnter (Collision col){
//		if (col.gameObject.tag == "PlayerFoot"){ 
//			Rigidbody rb =this.gameObject.GetComponent<Rigidbody> ();
//			rb.velocity = new Vector3 (10,10, 10);
//			rb.useGravity = false;
//			this.gameObject.GetComponent<BoxCollider> ().enabled = false;
//			if(this.gameObject.GetComponent<Animator> () != null){
//				this.gameObject.GetComponent<Animator> ().enabled = false;
//			}


		}

