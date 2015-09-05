using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Bullet(Clone)") {
			Destroy (other.gameObject);
			Debug.Log ("destroyed "+other.name +" "+this.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
