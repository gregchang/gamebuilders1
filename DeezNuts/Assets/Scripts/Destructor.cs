using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("destroyed "+other.name +" "+this.name);
		Destroy (other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
