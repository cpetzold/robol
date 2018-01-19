using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	public int teamIndex;
	public GameManager gameManager;

	Collider2D goalCollider;

	void Start () {
		goalCollider = GetComponent<Collider2D>();
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Ball" &&
			goalCollider.bounds.Contains(other.bounds.min) &&
			goalCollider.bounds.Contains(other.bounds.max))
		{
			gameManager.Score(teamIndex == 0 ? 1 : 0);
		}
	}
}
