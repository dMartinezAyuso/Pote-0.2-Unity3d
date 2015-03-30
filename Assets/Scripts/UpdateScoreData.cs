using UnityEngine;
using System.Collections;

public class UpdateScoreData : MonoBehaviour {

	public TextMesh total;
	public TextMesh record;
	public Score score;
	
	void OnEnable() {
		total.text = score.score.ToString ();
		if (GameState.gameState != null) {
			record.text = GameState.gameState.maxPoints.ToString ();
		}
	}

}
