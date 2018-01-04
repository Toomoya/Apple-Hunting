using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text;


public class csvManager
{
	/// <summary>
	/// Resourcesフォルダ内のcsvファイルを読み込み、string型2次元配列で返す。
	/// </summary>
	public static List<StageInfo> ReadCsvFile (string dataPath)
	{
		string data;
		string textData = OpenTextFile (GetPath () + dataPath);
		if (textData != "ERROR") {
			data = textData;
		} else {
			TextAsset textAsset = (TextAsset)Resources.Load (dataPath.Split ("." [0]) [0]);
			data = textAsset.ToString ();
		}

		if (data == null) {
			return null;
		}
		string[] rows = data.Replace ("\r\n", "\n").Split ('\n');

		List<StageInfo> newList = new List<StageInfo> ();
		for (int i = 1; i < rows.Length; i++) {
			string[] value = rows [i].Split (',');
			StageInfo tmpStageInfo = new StageInfo ();
			tmpStageInfo.stageId = int.Parse (value [0]);
			tmpStageInfo.highScore = int.Parse (value [1]);
			tmpStageInfo.bestTime = float.Parse (value [2]);
			tmpStageInfo.isCleared = value [3] == "1";
			tmpStageInfo.allAppleCount = int.Parse (value [4]);
			tmpStageInfo.allEnemyCount = int.Parse (value [5]);
			tmpStageInfo.allBoxCount = int.Parse (value [6]);
			tmpStageInfo.playCount = int.Parse (value [7]);
			newList.Add (tmpStageInfo);
		}
		return newList;
	}


	/// <summary>
	/// Resourcesフォルダ内に、ファイルを書き込む。
	/// 例) csvManager.WriteData("data.csv", dataArray);
	/// </summary>
	public static void WriteData (string dataPath, List<StageInfo> newData)
	{
		string stringData = "";

		//一番上の行を取得する
		string data;
		string textData = OpenTextFile (GetPath () + dataPath.Split ('.') [0]);
		if (textData != "ERROR") {
			data = textData;
		} else {
			TextAsset textAsset = (TextAsset)Resources.Load (dataPath.Split ("." [0]) [0]);
			data = textAsset.ToString ();
		}

		if (data == null) {
			return;
		}
		stringData = data.Replace ("\r\n", "\n").Split ('\n') [0] + "\n";


		for (int i = 0; i < newData.Count; i++) {
			string isCleared = newData [i].isCleared ? "1" : "0";
			//上の1行目と下の6行分は全く同じ意味
//			string isCleared;
//			if (newData [i].isCleared) {
//				isCleared = "1";
//			}else{
//				isCleared = "0";
//			}
			if (i + 1 != newData.Count) {
				stringData += newData [i].stageId.ToString () + "," + newData [i].highScore.ToString () + "," + newData [i].bestTime.ToString () + "," + isCleared + "," + newData [i].allAppleCount.ToString () + "," + newData [i].allEnemyCount.ToString () + "," + newData [i].allBoxCount.ToString () + "," + newData [i].playCount.ToString () + "\n";
			} else {
				stringData += newData [i].stageId.ToString () + "," + newData [i].highScore.ToString () + "," + newData [i].bestTime.ToString () + "," + isCleared + "," + newData [i].allAppleCount.ToString () + "," + newData [i].allEnemyCount.ToString () + "," + newData [i].allBoxCount.ToString () + "," + newData [i].playCount.ToString ();

			}
		}

		Debug.Log (GetPath () + dataPath);
		FileStream fs = new FileStream (GetPath () + dataPath, FileMode.Create);
		StreamWriter sw = new StreamWriter (fs);
		sw.Write (stringData);
		sw.Flush ();
		sw.Close ();
	}


	public static string GetPath ()
	{
		#if UNITY_EDITOR
		return Application.dataPath + "/Resources/";
		#elif UNITY_ANDROID
		return Application.persistentDataPath + "/";
		#elif UNITY_IPHONE
		return Application.persistentDataPath + "/";
		#else
		return Application.dataPath + "";
		#endif
	}

	public static string OpenTextFile (string _filePath)
	{
		FileInfo fi = new FileInfo (_filePath);
		string returnSt = "";
		if (fi.Exists) {
			StreamReader sr = new StreamReader (fi.OpenRead (), Encoding.UTF8);
			returnSt = sr.ReadToEnd ();
			sr.Close ();
		} else {
			returnSt = "ERROR";
		}
		return returnSt;
	}
}