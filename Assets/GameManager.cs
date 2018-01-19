using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text[] scoreTexts;
	int[] scores = { 0, 0 };

	void Start() {
		Cursor.visible = false;
	}

	void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R)) {
			Reset();
		}
	}

	public void Score(int teamIndex) {
		StartCoroutine(ScoreCo(teamIndex));
	}

	IEnumerator ScoreCo(int teamIndex) {
		scores[teamIndex]++;
		UpdateScoreText();
		Reset();

		yield return null;
	}

	void UpdateScoreText() {
		for (int i = 0; i < scoreTexts.Length; i++) {
			scoreTexts[i].text = scores[i].ToString();
		}
	}

	void Reset() {
		ResetRigidbody2D[] resetRigidBodies = FindObjectsOfType<ResetRigidbody2D>();

		foreach (ResetRigidbody2D rrb in resetRigidBodies) {
			rrb.Reset();
		}
	}
}
