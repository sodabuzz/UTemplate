using UnityEngine;
using System.Collections;

public class Duck : AbstractBehavior {

	public float scale = .5f;
	public bool ducking;
	public float centerOffsetY = 0f;

	private CircleCollider2D circleCollider;
	private Vector2 originalCenter;

	// Use this for initialization
	protected override void Awake () {
		// Call the parent class Awake method
		base.Awake ();

		circleCollider = GetComponent<CircleCollider2D> ();
		originalCenter = circleCollider.offset;
	}

	protected virtual void OnDuck(bool value){

		ducking = value;

		// when ducking dissable the scripts, when not ducking enable them
		ToggleScripts (!ducking);

		var size = circleCollider.radius;

		float newOffsetY;
		float sizeReciprocal;

		if (ducking) {
			sizeReciprocal = scale;
			newOffsetY = circleCollider.offset.y - size / 2 + centerOffsetY;
		} else {
			sizeReciprocal = 1 / scale;
			newOffsetY = originalCenter.y;
		}

		size = size * sizeReciprocal;
		circleCollider.radius = size;
		circleCollider.offset = new Vector2 (circleCollider.offset.x, newOffsetY);
	}
	
	void Update () {

		// Check if the Down button is pressed
		var canDuck = inputState.GetButtonValue (inputButtons [0]);

		// If down button + not in the air + not ducking: duck
		if(canDuck && collisionState.standing && !ducking) {
			OnDuck(true);
		} // else stop ducking
		else if(ducking && !canDuck){
			OnDuck(false);
		}
	}
}
