using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Keep track of the buttons states of the player
// Keep also track of the direction the player is looking at and its H and V velocity

public class ButtonState{
	public bool value; // Is the button pressed
	public float holdTime = 0; // How long the button is pressed
}

// The direction the player is looking at
public enum Directions {
	Right = 1,
	Left = -1
}

public class InputState : MonoBehaviour {

	public Directions direction = Directions.Right; // The default direction is set to right for all players
	public float absVelX = 0f;
	public float absVelY = 0f;

	private Rigidbody2D body2d;
	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState> (); // Keep track of the Buttons (enum) states (ButtonState) for that player

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		absVelX = Mathf.Abs (body2d.velocity.x);
		absVelY = Mathf.Abs (body2d.velocity.y);
	}

	// Used by the Input Manager to set the values of the buttonStates dictionary
	public void SetButtonValue(Buttons key, bool value){
		// Check if the key exists
		if (!buttonStates.ContainsKey (key))
			// If not: add the key and a new button state
			buttonStates.Add (key, new ButtonState ());

		// Get the actual value (the one already present in the dictionary) of the button
		var state = buttonStates [key];

		// If the actual value is true and the coming value is not true => Button released
		if (state.value && !value) {
			// When the button is released: reset its hold time
			state.holdTime = 0;
		} else if (state.value && value) {
			// When the button is pressed: Increment the hold time
			state.holdTime += Time.deltaTime;
		}

		// Set the new button's value
		state.value = value;
	}

	// Get the value of a button
	public bool GetButtonValue(Buttons key){
		if (buttonStates.ContainsKey (key))
			return buttonStates [key].value;
		else
			return false;
	}

	// Get the hold time of a button
	public float GetButtonHoldTime(Buttons key){
		if (buttonStates.ContainsKey (key))
			return buttonStates [key].holdTime;
		else
			return 0;
	}
}
