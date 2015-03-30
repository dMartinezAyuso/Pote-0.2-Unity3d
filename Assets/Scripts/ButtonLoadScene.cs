using UnityEngine;
using System.Collections;

public class ButtonLoadScene : MonoBehaviour {

	public string nameSceneToLoad = "GameScene";
		
	void OnMouseDown() {
		Camera.main.audio.Stop ();
		audio.Play ();
		Invoke ("LoadLevelGame", audio.clip.length);

	}

	void LoadLevelGame() {
		Application.LoadLevel (nameSceneToLoad);
	}
}
	