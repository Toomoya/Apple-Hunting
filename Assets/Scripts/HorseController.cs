using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController: MonoBehaviour {

	public GameObject horse;
	public float timer;
	public float pos;
	// Use this for initialization
	void Start () {
		timer = Random.Range (-2.1f, 1);
		pos = Random.Range (-1.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1.1f) {
			Instantiate (horse, this.transform.position +new Vector3(pos,0,0), this.transform.rotation);
			timer = Random.Range (-2.1f, 1);
		}
	}
}
