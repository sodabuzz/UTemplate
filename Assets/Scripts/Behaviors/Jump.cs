using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 200f;
	public float jumpDelay = .1f;
	public int jumpCount = 2;
	public GameObject dustEffectPrefab;

	protected float lastJumpTime = 0f;
	protected int jumpsRemaining = 0;

	protected virtual void Update () {
		var canjump = inputState.GetButtonValue (inputButtons [0]);
		var holdTime = inputState.GetButtonHoldTime (inputButtons [0]);

		// No auto-jump => remove holdTime
		if (collisionState.standing) {
			if (canjump && jumpCount > 0 && holdTime < .1f) {
				jumpsRemaining = jumpCount - 1;
				OnJump ();
			}
		} else // Double jump
		{
			if (canjump && jumpCount > 0 && holdTime < .1f && Time.time - lastJumpTime > jumpDelay) {
				if (jumpsRemaining > 0) {
					OnJump ();
					jumpsRemaining--;
					var dustPuff = Instantiate (dustEffectPrefab);
					dustPuff.transform.position = transform.position;
				}
			}
		}
	}

	protected virtual void OnJump() {
		var vel = body2d.velocity;
		lastJumpTime = Time.time;
		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
