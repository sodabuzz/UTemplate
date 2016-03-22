using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

	public float speed = 5f;
	public Buttons[] input;

	private Rigidbody2D body2D;
	private InputState inputState;

	void Start () {
		body2D = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}
	
	void Update () {
		var right = inputState.GetButtonValue (input [0]);
		var left = inputState.GetButtonValue (input [1]);
		var velX = speed;

		if (right || left) {
			velX *= left ? -1 : 1;
		} else {
			velX = 0;
		}

		body2D.velocity = new Vector2 (velX, body2D.velocity.y);
	}
}
