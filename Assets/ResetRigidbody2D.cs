using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRigidbody2D : MonoBehaviour {
	Rigidbody2D rigidBody;
	Vector2 startingPosition;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		startingPosition = rigidBody.position;
	}

	public void Reset() {
		rigidBody.angularVelocity = 0;
		rigidBody.velocity = Vector2.zero;
		rigidBody.position = startingPosition;
	}
}
