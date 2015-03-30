using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameState : MonoBehaviour {

	public int maxPoints = 0;
	public static GameState gameState;

	private String pathFile;

	void Awake () {
		pathFile = Application.persistentDataPath + "/data.dst";
		if (gameState == null) {
			gameState = this;		
			DontDestroyOnLoad (gameObject);
		} else if (gameState != this) {
			Destroy(gameObject);
		}
	}

	void Start() {
		LoadGame ();
	}

	public void SaveGame () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (pathFile);

		SaveData data = new SaveData ();
		data.maxPoints = maxPoints;

		bf.Serialize (file, data);

		file.Close ();
	}

	void LoadGame() {
		if(File.Exists(pathFile)){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (pathFile, FileMode.Open);

			SaveData data = (SaveData)bf.Deserialize (file);

			maxPoints = data.maxPoints;

			file.Close ();
		}
		else{
			maxPoints = 0;
		}
	}
}

[Serializable]
class SaveData {
	public int maxPoints;
}	
