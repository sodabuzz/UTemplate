using UnityEngine;
using System.Collections;

public class DestroyOffscreenY : MonoBehaviour {

	public float offset = 16f;
	public delegate void OnDestroy();
	public event OnDestroy DestroyCallback;

	private bool offscreen;
	private float offscreenY = 0;
	private Rigidbody2D body2d;

	void Awake() {
		body2d = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		offscreenY = (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
	}

	// Update is called once per frame
	void Update () {
		var posY = transform.position.y;
		var dirY = body2d.velocity.y;

		if (Mathf.Abs (posY) > offscreenY) {
			if (dirY < 0 && posY < -offscreenY) {
				offscreen = true;
			} else if (dirY > 0 && posY > offscreenY) {
				offscreen = true;
			}
		} else {
			offscreen = false;
		}

		if (offscreen) {
			OnOutOfBound();
		}
	}

	public void OnOutOfBound() {
		offscreen = false;
		GameObjectUtil.Destroy (gameObject);

		if (DestroyCallback != null) {
			DestroyCallback();
		}
	}
}
