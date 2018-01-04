using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienController : MonoBehaviour {

	Animator animator;
	Rigidbody rigidbody;
	public float time;
	public float interval;

	public float pojix;
	public float pojiy;
	public float pojiz;
	public float adjustPoji;

	public int deg;

	private Vector3 pos;
	public GameObject bullet;
	public GameObject bomb;
	public GameObject goal;
	bool isAlive;

	float shotOrBomb;

//	AudioSource audioSource;
//	public AudioClip Bomber;

	int hp=5;
	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		rigidbody = this.gameObject.GetComponent<Rigidbody> ();
		pos = this.transform.position;
		shotOrBomb = Random.Range (-1, 3);
		adjustPoji = Random.Range (-2, 2);
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= interval) {
			//Animation ();
			animator.SetBool ("shot", true);
			if (time >= interval + 2) {
				if (isAlive == true) {
					if (shotOrBomb > 0.5f) {
						Shoot ();
						time = 0.0f;
					} else {
						Bomb ();
						time = 0.0f;
					}
				}
			}
		}

	}
	void Shoot(){
		Instantiate (bullet,new Vector3(pos.x+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		Instantiate (bullet,new Vector3(pos.x+3.5f*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0));
		Instantiate (bullet,new Vector3(pos.x-3.5f*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		Instantiate (bullet,new Vector3(pos.x+7*pojix+adjustPoji,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		Instantiate (bullet,new Vector3(pos.x-7*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		shotOrBomb = Random.Range (-1, 3);
		adjustPoji = Random.Range (-2, 2);
		animator.SetBool ("shot", false);

	}
	void Bomb(){
		Instantiate (bomb,new Vector3(pos.x+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		Instantiate (bomb,new Vector3(pos.x+3.5f*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0));
		Instantiate (bomb,new Vector3(pos.x-3.5f*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		Instantiate (bomb,new Vector3(pos.x+7*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		Instantiate (bomb,new Vector3(pos.x-7*pojix+adjustPoji ,pos.y+pojiy ,pos.z+pojiz ),Quaternion.Euler (0,deg, 0)) ;
		shotOrBomb = Random.Range (-1, 3);
		adjustPoji = Random.Range (-2, 2);
		animator.SetBool ("shot", false);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Fire") {
			animator.SetTrigger ("hit");
//			audioSource.clip = Bomber;
//			audioSource.Play ();
			hp--;
			if (hp <= 0) {
				animator.SetTrigger ("dead");
				isAlive = false;
				Instantiate(goal,new Vector3(224.5f,-9.6f,38.7f),Quaternion.Euler(0,0,0));
			}
		}
	}
//	void Animation(){
//		//animator.SetTrigger ("getGun");
//		animator.SetBool ("shot", true);
//		animator.SetBool ("shot", false);
//		animator.SetTrigger ("isIdle");
			


}
