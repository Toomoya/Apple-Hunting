using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour {

	public GameObject objTarget;
	public Vector3 offset;

	void Start(){
		updatePosition ();
	}

	void LateUpdate(){
		updatePosition ();
		transform.Rotate (0, 3, 0);
	}

	void updatePosition(){
		Vector3 pos = objTarget.transform.localPosition;
		transform.localPosition=pos + offset;
	}
}
