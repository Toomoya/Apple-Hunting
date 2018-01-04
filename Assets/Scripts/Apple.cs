using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
	private Vector3 initialPosition;

	AudioSource audioSource;
	bool isHit;
	Vector3 direction;
	public GameObject targetObj;
	float speed=0f;
	public float timer = 1;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (isHit == false) {
			transform.position = new Vector3 (initialPosition.x, Mathf.Sin (Time.time) * 0.1f + initialPosition.y, initialPosition.z);
			transform.Rotate (0, 3, 0);
		} else {
			timer += Time.deltaTime;
			direction = Vector3.Normalize (targetObj.transform.position - this.gameObject.transform.position);
			if (speed < 10) {
				speed = 1.2f * timer * timer * timer * timer * timer * timer * timer;
			}
			this.transform.position += direction * speed * Time.deltaTime;
			if(Vector3.Distance(targetObj.transform.position,this.gameObject.transform.position)<0.5f || timer>1.5f){
				GameObject.Find("MAX").GetComponent<MaxController> ().AppleCount ();
				Destroy (this.gameObject);

			}

		}
	}
	public void OnHitPlayer(){
		
		isHit = true;
		targetObj = GameObject.Find ("AppleCount");

	}
}
