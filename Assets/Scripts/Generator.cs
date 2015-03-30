using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] obj;
	public float timeMin = 1.4f;
	public float timeMax = 2.8f;

	private bool endGame = false;

	void Start () {
		AddNotificationObserver (this, "PlayerRunning");
		AddNotificationObserver (this, "PlayerDeath");
	}

	void AddNotificationObserver (Generator anGenerator, string nameObserver) {
		NotificationCenter.DefaultCenter ().AddObserver (anGenerator, nameObserver);
	}

	void PlayerDeath() {
		endGame = true;
	}

	void PlayerRunning(Notification notification) {
		Generate ();
	}

	void Generate () {
		if (!endGame) {
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
			Invoke ("Generate", Random.Range (timeMin, timeMax));
		}
	}

}
