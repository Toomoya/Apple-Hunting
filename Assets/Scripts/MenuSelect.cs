using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {


	public Button[] button = new Button[9];

	DataManager dataManager;

	int j;
	void Start(){
		dataManager = GameObject.Find ("DataManager").GetComponent<DataManager> ();
		for (j = 0; j < dataManager.stageInfoList.Count; j++) {
			if (dataManager.stageInfoList[j].isCleared== true) {
				button [j+1].interactable = true;
			} else {
				break;
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown ("1") == true) {
			SceneManager.LoadScene ("Stage1");
		}
		if (Input.GetKeyDown ("2") == true) {
			SceneManager.LoadScene ("Stage2");
		}
		if (Input.GetKeyDown ("3") == true) {
			SceneManager.LoadScene ("Stage3");
		}
//		if (Input.GetKeyDown ("4") == true) {
//			SceneManager.LoadScene ("Stage4");
//		}
//		if (Input.GetKeyDown ("5") == true) {
//			SceneManager.LoadScene ("Stage5");
//		}
//		if (Input.GetKeyDown ("6") == true) {
//			SceneManager.LoadScene ("Stage6");
//		}
//		if (Input.GetKeyDown ("7") == true) {
//			SceneManager.LoadScene ("Stage7");
//		}
//		if (Input.GetKeyDown ("8") == true) {
//			SceneManager.LoadScene ("Stage8");
//		}
//		if (Input.GetKeyDown ("9") == true) {
//			SceneManager.LoadScene ("Stage9");
//		}
	}
	public void StageSelect(int i){
		GameObject.Find ("DataManager").GetComponent<DataManager> ().selectedStageId = i + 1;
		if (i == 0) {
			SceneManager.LoadScene ("Stage1");
		}
		if (i == 1) {
			SceneManager.LoadScene ("Stage2");
		}
		if (i == 2) {
			SceneManager.LoadScene ("Stage3");
		}
		if (i == 3) {
			SceneManager.LoadScene ("Stage4");
		}
		if (i == 4) {
			SceneManager.LoadScene ("Stage5");
		}
		if (i == 5) {
			SceneManager.LoadScene ("Stage6");
		}
		if (i == 6) {
			SceneManager.LoadScene ("Stage7");
		}
		if (i == 7) {
			SceneManager.LoadScene ("Stage8");
		}
		if (i == 8) {
			SceneManager.LoadScene ("Stage9");
		}

	}
}



//りんごのフリー素材を集めてボタンをりんごにする(2Dでもいいかな）
//背景もただの緑じゃつまらないかな
//button押したときの音とかあったらいいかも
//fontもそろそろ欲しい（全体での統一感あったほうがいい）