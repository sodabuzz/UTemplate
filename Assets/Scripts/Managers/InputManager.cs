using UnityEngine;
using System.Collections;

// Our own custom Input Manager. It is used to define only the keys that are going to be used in a specific game
// One Input Manager is used per player

// The buttons to the Unity Input Manager
public enum Buttons{
	Right,
	Left,
	Up,
	Down,
	A,
	B
}

public enum Condition{
	GreaterThan,
	LessThan
}

// InputAxisState defined the axis used in our own Input Manager
// It is necessary to serialize that class in order to display it in the IDE
[System.Serializable]
public class InputAxisState{
	public string axisName;
	public float offValue;
	public Buttons button;
	public Condition condition;

	public bool value{
		// Detects if a button is pressed or not
		// Usually getters are used to acces private variables, here it is used checked the buttons pressed relataed to the offValue (threshold) 
		// and to makes value read-only
		get{
			var val = Input.GetAxis (axisName);
			
			switch(condition){
			case Condition.GreaterThan:
				return val > offValue;
			case Condition.LessThan:
				return val < offValue;
			}

			return false;
		}
	}
}

public class InputManager : MonoBehaviour {

	public InputAxisState[] inputs;
	public InputState inputState;
	
	void Update () {
		// Loops on all the inputs to find which button is pressed or not
		foreach (var input in inputs) {
			// Set the player Input State values
			inputState.SetButtonValue (input.button, input.value);
		}
	}
}
