using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown(){
		Main.shooting = true;
		Debug.Log("shooting");
	}
	void OnMouseUp(){
		Main.shooting = false;
		Debug.Log("stop");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
