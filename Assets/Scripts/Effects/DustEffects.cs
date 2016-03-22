using UnityEngine;
using System.Collections;

public class DustEffects : MonoBehaviour {

	void OnDestroy(){
		Destroy (gameObject);
	}
}
