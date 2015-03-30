using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public int pointsToIncrease = 1;

	private bool collisionedWithPlayer = false;

	void OnCollisionEnter2D(Collision2D collision) {
		if (!collisionedWithPlayer && collision.gameObject.tag == "Player"	) {
			GameObject obj = collision.contacts[0].collider.gameObject;
			if(obj.name == "Pierna Izquierda" || obj.name == "Pierna Derecha") {
				collisionedWithPlayer = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "IncreasePoints", pointsToIncrease);
			}
		}
	}

}
