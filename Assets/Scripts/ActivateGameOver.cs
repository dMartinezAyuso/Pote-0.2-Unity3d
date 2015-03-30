using UnityEngine;
using System.Collections;

public class ActivateGameOver : MonoBehaviour {

	public GameObject gameOverCamera;
	public AudioClip gameOverClip;

	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerDeath");
	}

	void PlayerDeath(Notification notification) {
		audio.Stop ();
		audio.clip = gameOverClip;
		audio.loop = false;
		audio.Play();
		gameOverCamera.SetActive (true);
	}

}
