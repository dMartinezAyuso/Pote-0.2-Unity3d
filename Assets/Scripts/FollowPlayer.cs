using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public float offsetAxeXPlayer = 7.5f;

	void Update () {
		transform.position = new Vector3 (player.position.x + offsetAxeXPlayer, transform.position.y, transform.position.z);
	}

}
