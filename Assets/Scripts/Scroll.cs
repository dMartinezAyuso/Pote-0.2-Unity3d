using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocity = 0f;
	public bool startInMotion = false;

	private bool inMotion = false;
	private float startTime = 0f;

	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PlayerRunning");
		NotificationCenter.DefaultCenter().AddObserver(this, "PlayerDeath");
		if (startInMotion) {
			PlayerRunning ();
		}
	}

	void PlayerDeath() {
		inMotion = false;
	}

	void PlayerRunning () {
		inMotion = true;
		startTime = Time.time;
	}

	void Update () {
		if (inMotion) {
			renderer.material.mainTextureOffset = new Vector2 (((Time.time-startTime) * velocity)%1, 0);
		}
	}

}
