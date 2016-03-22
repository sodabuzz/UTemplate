using UnityEngine;
using System.Collections;

// Manage the Walk behavior

// Inherits from the AbstractBehavior class
public class Walk : AbstractBehavior {

	public float speed = 50f;
	public float runMultiplier = 2f;
	public bool running;

	void Update () {

		running = false;

		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);
		var run = inputState.GetButtonValue (inputButtons [2]);

		// If walking
		if (right || left) {
			var tmpSpeed = speed;
			// If running
			if (run && runMultiplier > 0) {
				tmpSpeed *= runMultiplier;
				running = true;
			}

			// Multiply the speed by the direction to get the proper velocity sign
			var velX = tmpSpeed * (float)inputState.direction;
			// Apply the velocity
			body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		}
	}
}
