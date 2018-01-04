using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject objTarget;
	public Vector3 offset;

	void Start(){
		updatePosition ();
	}

	void LateUpdate(){
		updatePosition ();
	}

	void updatePosition(){
		Vector3 pos = objTarget.transform.localPosition;
		transform.localPosition=pos + offset;
	}
}
