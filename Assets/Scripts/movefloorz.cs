using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefloorz : MonoBehaviour {

	[SerializeField] int power;
	public Vector3 vct3 = new Vector3(0, 0, -1);

	//力を加える→Addforce Method

	private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (initialPosition.x, initialPosition.y, Mathf.Sin (1.5f*Time.time) * 2.0f + initialPosition.z);
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("hit");
			col.gameObject.GetComponent<Rigidbody>().AddForce (vct3 * power, ForceMode.Impulse);


		}
	}
}
