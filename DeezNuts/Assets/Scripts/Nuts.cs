using UnityEngine;
using System.Collections;

public class Nuts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			Destroy (this.gameObject);
			Debug.Log ("destroyed "+other.name +" "+this.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
