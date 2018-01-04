using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaxController : MonoBehaviour
{
	Animator animator;
	AudioSource audioSource;
	public float speed = 5;
	public float jumpPower = 10;
	int jumpCount;
	public int appleCount = 0;
	public int boxCount;
	public float timeCount;
	float timer;
	public Text appleText;
	public Text deathMessage;


	public AudioClip Bomber;
	public AudioClip dead;
	public AudioClip RotateAttack;
	public AudioClip FlyAway;
	public AudioClip Apples;
	public AudioClip jump;
	int i;
	int stageNo;

	public GameObject ExploadObj;
	public GameObject ExploadPos;

	public GameObject DestroyBox;
	public GameObject DestroyedObject;
	public bool isAttacking = false;
	public bool isGoal = false;
	Rigidbody rigidbody;

	float lastBoxCollideTime;
	float lastGoalCollideTime;

	bool isLeftButtonDown;
	bool isRightButtonDown;

	bool isTime=true;

	DataManager dataManager;

	void Start ()
	{
		
		dataManager = GameObject.Find ("DataManager").GetComponent<DataManager> ();
		appleText.text = "0";
		animator = this.gameObject.GetComponent<Animator> ();
		rigidbody = this.gameObject.GetComponent<Rigidbody> ();
		audioSource = this.gameObject.GetComponent<AudioSource> ();
		stageNo = GameObject.Find ("DataManager").GetComponent<DataManager> ().selectedStageId;
		SelectStage (stageNo);
	}

	void SelectStage (int k)
	{
		dataManager.stageInfoList [k - 1].playCount += 1;
		dataManager.Save ();
	}



	void Update ()
	{
		Animation ();
		Move ();
		TimeCounter ();
		if (isAttacking == true) {
			timer += Time.deltaTime;
			transform.Rotate (new Vector3 (0, 90, 0));
			if (timer > 0.5f) {
				timer = 0;
				animator.SetBool ("isAttack", false);
				Invoke("AttackInterval" ,0.2f);

				//this.transform.rotation = Quaternion.Euler (0, 90, 0);
			}
		}
	}

	void TimeCounter ()
	{
		timeCount += Time.deltaTime;

	}
	void AttackInterval(){
		isAttacking = false;

	}


	void Animation ()
	{
		if (Input.GetKeyDown ("right") == true || Input.GetKeyDown ("left") == true) {
				animator.SetBool ("isRunning", true);
		}
		if (Input.GetKeyUp ("right") == true || Input.GetKeyUp ("left") == true) {
			animator.SetBool ("isRunning", false);
		}
		if (Input.GetKeyDown ("a") == true) {
			Attack ();
		}
	}

	void Move ()
	{
		if (Input.GetKey ("right") == true || isRightButtonDown == true) {
			if (isAttacking == false) {
				this.transform.rotation = Quaternion.Euler (0, 90, 0);
			}//回転攻撃と競合している部分
			this.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey ("left") == true || isLeftButtonDown == true) {
			if (isAttacking == false) {
				this.transform.rotation = Quaternion.Euler (0, 270, 0);
			}
			this.transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKeyDown ("space") == true) {
			if (jumpCount < 2) {
				Jump (true);
			}
		}
	}

	void Attack ()
	{
		isAttacking = true;
		audioSource.clip = RotateAttack;
		audioSource.Play ();
		animator.SetBool ("isAttack", true);
		//animator.SetTrigger ("Attack");
	}

	void Jump (bool isAddJumpCount)
	{
		animator.SetTrigger ("jump");
		rigidbody.velocity = new Vector3 (0, jumpPower, 0);
		audioSource.clip = jump;
		audioSource.Play ();
		if (isAddJumpCount) {
			jumpCount += 1;
		} 
	}

		


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Ground") {
			jumpCount = 0;
			//audioSource.clip = JumpEnd;
			//audioSource.Play ();
		}
		if (col.gameObject.tag == "Box") {
			if (Time.time - lastBoxCollideTime > 0.1f) {
				Jump (false);
				Destroy (col.transform.parent.gameObject);
				Instantiate (DestroyedObject, transform.position - new Vector3 (0, 1.2f, 0), transform.rotation);
				boxCount++;
				lastBoxCollideTime = Time.time;
			}

		}
		if (col.gameObject.tag == "Enemy") {
			if (isAttacking == true) {
//				if(col.gameObject.GetComponent<Horse>() !=null){
//					col.gameObject.GetComponent<Horse> ().enabled == false;
//				}
				Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
				rb.velocity = new Vector3 (10, 10, 10);
				audioSource.clip = FlyAway;
				audioSource.Play ();
				rb.useGravity = false;
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
				if (col.gameObject.GetComponent<Animation> () != null) {
					col.gameObject.GetComponent<Animation> ().enabled = false;
				}
				Destroy (col.gameObject, 2.0f);
			} else {
				death ();
			}
		}
		if (col.gameObject.tag == "Fire") {
			if (isAttacking != true) {
				death ();
			}
		}
		if (col.gameObject.tag == "Goal") {
			if (Time.time - lastGoalCollideTime > 0.5f) {
				Debug.Log ("お疲れ");
				isGoal = true;
				dataManager.stageInfoList [stageNo - 1].isCleared = true;
				dataManager.Save ();
				lastGoalCollideTime = Time.time;
				Invoke ("GoalScene", 2.0f);
			}
		}

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Apple") {
			col.gameObject.GetComponent<Apple> ().OnHitPlayer ();
		}
		if (col.gameObject.tag == "Bomb") {
			Instantiate (ExploadObj, this.gameObject.transform.position, Quaternion.identity);
			audioSource.clip = Bomber;
			audioSource.Play ();
			Destroy (col.gameObject);
			Invoke ("death", 0.1f);
		}
//		if (col.gameObject.tag == "Box") {
//			Jump (false);
//			Destroy (col.transform.parent.gameObject);
//			Instantiate (DestroyedObject, transform.position, transform.rotation);
//		}
		if (col.gameObject.tag == "Enemy2") {
			Jump (false);
		}
		if (col.gameObject.tag == "Death") {
			audioSource.clip = dead;
			audioSource.Play ();
			appleCount = 0;
			boxCount = 0;
			timeCount = 99999;
			Restart ();
		}
	}

	void death ()
	{
		deathMessage.text = "GAMEOVER";
		animator.SetTrigger ("dead");
		audioSource.clip = dead;
		audioSource.Play ();
		appleCount = 0;
		boxCount = 0;
		timeCount = 99999;
		Invoke ("Restart", 2.0f);
	}
	void Restart(){
		SceneManager.LoadScene ("Stage" + dataManager.selectedStageId.ToString ());
	}


	void GoalScene ()
	{
		PlayerPrefs.SetInt ("appleScore", appleCount);
		PlayerPrefs.SetInt ("boxScore", boxCount);
		PlayerPrefs.SetFloat ("timeScore", timeCount);
		SceneManager.LoadScene ("ClearScene");
	}

	public void AppleCount ()
	{
		appleCount += 1;
		appleText.text = appleCount.ToString ();
		audioSource.clip = Apples;
		audioSource.Play ();
	}

	public void JumpButton ()
	{
		if (jumpCount < 2) {
			Jump (true);
		}
	}

	public void AttackButton ()
	{
		Attack ();
	}

	public void LeftButtonDown ()
	{
		isLeftButtonDown = true;
		animator.SetBool ("isRunning", true);
	}

	public void LeftButtonUp ()
	{
		isLeftButtonDown = false;
		animator.SetBool ("isRunning", false);
	}

	public void RightButtonDown ()
	{
		isRightButtonDown = true;
		animator.SetBool ("isRunning", true);
	}

	public void RightButtonUp ()
	{
		isRightButtonDown = false;
		animator.SetBool ("isRunning", false);
	}
	public void StopButton(){
		if (isTime == true) {
			Time.timeScale = 0;
			isTime = false;
		} else {
			Time.timeScale = 1.0f;
			isTime = true;
		}
	}
	public void MenuButton(){
		SceneManager.LoadScene ("Menu");
	}
}
	

//やること　音、フォント,ステー
//どんな音をつけるか？
//ジャンプ時
//回転時
//敵が飛ぶとき
//BGM
//りんごを取得したとき
//死んだとき
//ショットエネミーが弾を打つとき
//クリアシーン
//新しい動画教材を学習→配列とかを学習、得点化する時のデータ保持について考えとく
//りんご数、時間、クリアボーナス

//どうやってユーザの心を掴むか、また、離さないか
//短期的なスパンか長期的なスパンかどう楽しんでもらえるかどうか
//プレゼンでクラッシュの動画を流した方が分かりやすい
//プレゼンで何を推しているのか、強調する部分を考える
//フックになるような言葉を考えておく方がいい
//反則とか裏切り的な部分を入れる
//悔しがらせる
//オブジェクトの色が被って見にくいところがある

//落ちた時はりんごゲット全くできない
//爆弾受けた時と敵に当たった時は


//ロードシーン