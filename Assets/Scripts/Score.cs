using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public TextMesh scoreBoard;
	public int score = 0;

	void Start () {
		UpdateScoreBoard ();
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncreasePoints");
		NotificationCenter.DefaultCenter ().AddObserver (this, "PlayerDeath");
	}

	void PlayerDeath(Notification notification) {
		if (score > GameState.gameState.maxPoints) {
			//Debug.Log ("Puntuacion maxima superada:::" + GameState.gameState.maxPoints + "---Actual:::" + score);
			GameState.gameState.maxPoints = score;
			GameState.gameState.SaveGame ();
		} /*else {
			Debug.Log ("Puntuacion NO superada:::" + GameState.gameState.maxPoints + "---Actual:::" + score);
		}*/
	}

	void IncreasePoints(Notification notification) {
		int pointsToIncrease = (int)notification.data;
		score += pointsToIncrease;
		UpdateScoreBoard ();
	}

	void UpdateScoreBoard() {
		scoreBoard.text = score.ToString();
	}

}
