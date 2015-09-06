using UnityEngine;
using System.Collections;

public class Titlepage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log (Input.GetAxis ("Fire1"));

		if(Input.GetAxis("Fire1")>0) {
			Application.LoadLevel("Level1");
	}


}
}