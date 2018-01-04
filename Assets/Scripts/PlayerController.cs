using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	float maxHP=5;
	float currentHP=5;
	public Image hpImage;

	public float speed=5;
	public float jumpPower = 5;
	int jumpCount;

	public AudioClip pickUpSound;
	public AudioClip jumpSound;

	AudioSource audioSource;
	Animator animator;

	bool leftMove;
	bool rightMove;

	// Use this for initialization
	void Start () {
		audioSource = this.gameObject.GetComponent<AudioSource> ();
		animator = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Animation ();


	}
	void Move(){
		if(Input.GetKey("right")==true || rightMove==true){
			this.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}
		if(Input.GetKey("left")==true || leftMove==true){
			this.transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown("space") == true) {
			Jump ();
		}

	}
	public void Jump(){
		if(jumpCount<2){
			this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, jumpPower, 0);
			audioSource.clip = jumpSound;
			audioSource.Play ();
			jumpCount += 1;
		}
	
	
	}
	void Animation(){
		if (Input.GetKeyDown ("right") == true) {
			animator.SetBool ("WalkRight", true);
		}
		if (Input.GetKeyUp ("right") == true) {
			animator.SetBool ("WalkRight", false);
		}

		if (Input.GetKeyDown ("left") == true) {
			animator.SetBool ("WalkLeft", true);
		}
		if (Input.GetKeyUp ("left") == true) {
			animator.SetBool ("WalkLeft", false);
		}

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground" || col.gameObject.tag=="Box") {
			jumpCount = 0;
		
		}
		if (col.gameObject.tag == "Coin") {
			audioSource.clip = pickUpSound;
			audioSource.Play();
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			currentHP -= 1;
			hpImage.fillAmount = currentHP / maxHP;
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Goal") {
			Debug.Log ("お疲れ");
		}
	}


	public void LeftButtonDown(){
		leftMove = true;
		animator.SetBool ("WalkLeft", true);
	}
	public void LeftButtonUp(){
		leftMove = false;
		animator.SetBool ("WalkLeft", false);
	}
	public void RightButtonDown(){
		rightMove = true;
		animator.SetBool ("WalkRight", true);
	}
	public void RightButtonUp(){
		rightMove = false;
		animator.SetBool ("WalkRight", false);
	}

}
