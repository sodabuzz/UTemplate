using UnityEngine;
using System.Collections;

// Manage the switch of animation for the different behaviors

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;
	private CollisionState collisionState;
	private Duck duckBehavior;

	// Get the behavior components
	void Awake () {
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
		//duckBehavior = GetComponent<Duck> ();
	}
	
	void Update () {

		// Player is idle
		if (collisionState.standing) {
			ChangeAnimationState (0);
		}

		// player is walking/running
		if (inputState.absVelX > 0) {
			ChangeAnimationState (1);
		}

		// Player is jumping
		if (inputState.absVelY > 0) {
			ChangeAnimationState (2);
		}

		// Change the animation speed when walking/running
		//animator.speed = walkBehavior.running ? walkBehavior.runMultiplier : 1;

		// Player is ducking
		//if (duckBehavior.ducking) {
		//	ChangeAnimationState (3);
		//}

		// Player is on the wall side
		if (!collisionState.standing && collisionState.onWall) {
			ChangeAnimationState (4);
		}
	}

	// Change the animation
	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
