using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako1Controller : MonoBehaviour {


	private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Sin (Time.time) * 1.5f + initialPosition.x, initialPosition.y, initialPosition.z);
	}
}


