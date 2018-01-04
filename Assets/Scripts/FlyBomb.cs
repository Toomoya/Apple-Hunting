using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBomb : MonoBehaviour {
	public int speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	void Move(){
		this.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		Destroy (this.gameObject, 5.0f);
	}
}
