using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour {

	int apples;
	int counter=0;
	public GameObject apple;
	float time;
	private Vector3 pos;
	public Text appleCount;
	public Text AllappleText;
	public Text AllBoxText;
	public Text GetAppleText;
	int stageNo;
	int maxApple;
	int maxBox;
	int maxEnemy;
	int highScore;
	int boxes;
	float best_Time;
	float times;
	DataManager dataManager;



	// Use this for initialization
	void Start () {
		this.transform.rotation = Quaternion.Euler (30, 180, 0);
		dataManager=GameObject.Find ("DataManager").GetComponent<DataManager> ();
		apples = PlayerPrefs.GetInt ("appleScore");
		boxes = PlayerPrefs.GetInt ("boxScore");
		times = PlayerPrefs.GetFloat ("timeScore");
		pos = transform.position;
		stageNo = dataManager.selectedStageId;
		maxApple = dataManager.stageInfoList [stageNo-1].allAppleCount;
		maxBox = dataManager.stageInfoList[stageNo-1].allBoxCount;
		//maxEnemy = dataManager.stageInfoList [stageNo-1].allEnemyCount;
		highScore = dataManager.stageInfoList [stageNo-1].highScore;
		best_Time = dataManager.stageInfoList [stageNo-1].bestTime;
		GetAppleText.text = "You Get " + apples + " apples";
		Bonus ();
	}

	void Bonus(){
		if (apples == maxApple) {
			apples += 30;
			AllappleText.text = "Apple Bonus +30";
		}
		if (boxes == maxBox) {
			apples += 20;
			AllBoxText.text = "Box Bonus +20";
		}
		if (times < best_Time) {
			
			best_Time = times;
			dataManager.stageInfoList [stageNo-1].bestTime=best_Time;
			dataManager.Save ();
		}
		if (apples > highScore) {
			highScore = apples;
			dataManager.stageInfoList [stageNo - 1].highScore = highScore;
			dataManager.Save ();
		}

	}

	// Update is called once per frame
	void Update () {
			time += Time.deltaTime;
		if (counter < apples) {
			if (time >= 0.1) {
				Instantiate (apple, new Vector3 (pos.x, pos.y+0.3f, pos.z - 0.5f), Quaternion.Euler (0, 180, 0));
				time = 0.0f;
				counter++;
				appleCount.text = "Score is "+counter.ToString ()+"00";
			}
		}


	}
	public void MenuButton(){
		SceneManager.LoadScene ("Menu");
	}


}


