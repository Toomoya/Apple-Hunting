using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	public float speed;
	public int degree;
	bool isMove=true;

	public GameObject targetObj;
	public GameObject explosion;
	float timer;
	Vector3 direction;
	// Use this for initialization
	void Start () {
		this.transform.rotation = Quaternion.Euler (0, degree, 0);
	}

	// Update is called once per frame
	void Update () {
		if (isMove == true) {
			Move ();
		} else {
			Attack ();
		}
	}
	void Move(){
		this.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		Destroy (this.gameObject, 5.0f);
	}
	void Attack(){
		targetObj = GameObject.Find ("alien");
		timer += Time.deltaTime;
		direction = Vector3.Normalize (targetObj.transform.position - this.gameObject.transform.position+new Vector3(0,0,55));
		this.transform.position += direction * speed * Time.deltaTime;
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.GetComponent<MaxController> ().isAttacking == true) {
				isMove = false;
		}

	}
		if (col.gameObject.tag == "Enemy") {
			Instantiate (explosion, this.transform.position, Quaternion.Euler (0,0, 0));
			Destroy (this.gameObject);
		}
}

}