using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako2Controller : MonoBehaviour {

	private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 ( initialPosition.x,Mathf.Sin (Time.time) * 1.0f + initialPosition.y, initialPosition.z);
	}
}
