using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public static DataManager instance;
	public int lastAppleCount;
	public float lastPlayTime;
	[SerializeField]
	public List<StageInfo> stageInfoList = new List<StageInfo> ();

	public int lastScore;

	public int selectedStageId;

	void Awake ()
	{
		if (instance == null) {
			DontDestroyOnLoad (this.gameObject);
			instance = this;
		} else {
			Destroy (this.gameObject);
		}

		stageInfoList = csvManager.ReadCsvFile ("StageInfo");

	}

	void Start ()
	{

	}

	public void Save(){
		csvManager.WriteData ("StageInfo.csv", stageInfoList);
	}
}
