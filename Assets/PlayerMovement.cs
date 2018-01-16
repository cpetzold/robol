using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public LayerMask groundLayer;
	public CircleCollider2D groundCheck;

	public string jumpButton;
	public string boostAxis;
	public string horizontalAxis;
	public string verticalAxis;

	public float acceleration = 10f;
	public float maxSpeed = 20f;
	public float jumpForce = 20f;
	public float boostForce = 20f;

	private Rigidbody2D rigidBody2D;
	private bool jumpPressed = false;
	private bool hasDoubleJump = true;

	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (Input.GetButtonDown (jumpButton)) {
			jumpPressed = true;
		}
	}

	void Jump() {
		rigidBody2D.AddForce (Vector2.up * jumpForce);
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis (horizontalAxis);
		float vertical = Input.GetAxis (verticalAxis);
		float boost = Input.GetAxis (boostAxis);

		rigidBody2D.AddForce (Vector2.right * horizontal * acceleration);
		if (boost > 0) {
			rigidBody2D.AddForce (new Vector2 (horizontal, -vertical) * boostForce);
		}
			

		if (Mathf.Abs(rigidBody2D.velocity.x) > maxSpeed) {
			rigidBody2D.velocity = new Vector2 (Mathf.Clamp (rigidBody2D.velocity.x, -maxSpeed, maxSpeed), rigidBody2D.velocity.y);
		}



		bool grounded = groundCheck.IsTouchingLayers (groundLayer);

		if (jumpPressed) {
			if (grounded) {
				Jump ();
				hasDoubleJump = true;
			} else if (hasDoubleJump) {
				Jump ();
				hasDoubleJump = false;
			}
		}

		jumpPressed = false;
	}
}
