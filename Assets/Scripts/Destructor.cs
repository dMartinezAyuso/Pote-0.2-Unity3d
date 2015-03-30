using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			NotificationCenter.DefaultCenter().PostNotification(this,"PlayerDeath");
			GameObject player = GameObject.Find("Player");
			player.SetActive(false);
		} else {
			Destroy (other.gameObject);
		}
	}

}
