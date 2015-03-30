using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int pointsToIncrease = 5;
	public AudioClip coinSoundClip;
	public float coinSoundVolume = 1f;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreasePoints", pointsToIncrease);
			AudioSource.PlayClipAtPoint(coinSoundClip, Camera.main.transform.position, coinSoundVolume);
		}
		Destroy (gameObject);
	}

}
