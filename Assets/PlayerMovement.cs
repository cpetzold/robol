using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public string jumpButton;
	public string horizontalAxis;

	public float acceleration = 10f;
	public float maxSpeed = 20f;
	public float jumpForce = 20f;

	private bool jump = false;
	private Rigidbody2D rigidBody2D;

	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (Input.GetButtonDown (jumpButton)) {
			jump = true;
		}
	}

	void FixedUpdate () {
		float move = Input.GetAxis (horizontalAxis);

		rigidBody2D.AddForce (Vector2.right * move * acceleration);
		if (Mathf.Abs(rigidBody2D.velocity.x) > maxSpeed) {
			rigidBody2D.velocity = new Vector2 (Mathf.Clamp (rigidBody2D.velocity.x, -maxSpeed, maxSpeed), rigidBody2D.velocity.y);
		}

		if (jump) {
			rigidBody2D.AddForce (Vector2.up * jumpForce);
			jump = false;
		}
	}
}
