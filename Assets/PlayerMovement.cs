using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour {
	public LayerMask groundLayer;
	public CircleCollider2D groundCheck;

	public int playerIndex = 0;

	public float acceleration = 10f;
	public float maxSpeed = 20f;
	public float jumpForce = 20f;
	public float boostForce = 20f;

	Rigidbody2D rigidBody2D;
	Player player;
	bool jumpPressed = false;
	bool hasDoubleJump = true;

	void Awake() {
		player = ReInput.players.GetPlayer(playerIndex);
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (player.GetButtonDown("Jump")) {
			jumpPressed = true;
		}
	}

	void Jump() {
		rigidBody2D.AddForce (Vector2.up * jumpForce);
	}

	void FixedUpdate () {
		float horizontal = player.GetAxis ("Horizontal");
		//float vertical = player.GetAxis ("Vertical");
		bool grounded = groundCheck.IsTouchingLayers (groundLayer);

		rigidBody2D.AddForce (Vector2.right * horizontal * acceleration);
		if (player.GetButton("Boost")) {
			rigidBody2D.AddForce ((grounded ? Vector2.right * horizontal * 0.5f : Vector2.up) * boostForce);
		}

		if (Mathf.Abs(rigidBody2D.velocity.x) > maxSpeed) {
			rigidBody2D.velocity = new Vector2 (Mathf.Clamp (rigidBody2D.velocity.x, -maxSpeed, maxSpeed), rigidBody2D.velocity.y);
		}


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
