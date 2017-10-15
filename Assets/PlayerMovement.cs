using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 10f;
	private Rigidbody2D rigidBody2D;

	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		rigidBody2D.velocity = new Vector2 (move * maxSpeed, rigidBody2D.velocity.y);
	}
}
