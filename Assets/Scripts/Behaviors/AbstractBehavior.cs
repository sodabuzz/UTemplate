using UnityEngine;
using System.Collections;

// This class will be inherited by all other behavior classes
// An abstract class cannot be instanciated. It is only used for inheritance
public abstract class AbstractBehavior : MonoBehaviour {

	// Those public variables will be available in all inherited classes and so visible in the IDE
	public Buttons[] inputButtons; // The buttons used for that specific behavior
	public MonoBehaviour[] dissableScripts; // The scripts that could interfere with that behavior and must be dissabled

	// private variable that can be accessed by inherited classes
	protected InputState inputState;
	protected Rigidbody2D body2d;
	protected CollisionState collisionState;

	// Get the main components used in behavior scripts
	protected virtual void Awake () {
		inputState = GetComponent<InputState> ();
		body2d = GetComponent<Rigidbody2D> ();
		collisionState = GetComponent<CollisionState> ();
	}

	// Dissable the behavior scripts that would interfere with that specific behavior
	// ea. You cannot run while you jump
	protected virtual void ToggleScripts(bool value){
		foreach (var script in dissableScripts) {
			script.enabled = value;
		}
	}
}
