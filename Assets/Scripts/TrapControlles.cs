using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControlles : MonoBehaviour {
	//-0.75から0
	// Use this for initialization
	public float trapSpeed;
	public float trapTime;
	private Vector3 initialPosition;
	void Start () {
		initialPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 ( initialPosition.x,initialPosition.y-0.25f-0.75f*Mathf.Sin(trapTime-trapSpeed*Time.time), initialPosition.z);
	}
}
