using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour {

	public Vector2 speed = Vector2.zero;

	private Vector2 offset = Vector2.zero;
	private Material material;

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer> ().material;

		// To get the offset of the main texture of the material
		offset = material.GetTextureOffset ("_MainTex");
	}
	
	void Update () {
		// deltatime is the difference between one frame rendering and another
		offset += speed * Time.deltaTime;

		material.SetTextureOffset("_MainTex", offset);
	}
}
