﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max2 : MonoBehaviour {


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Apple") {
			Destroy (col.gameObject);
		}
	}
}
