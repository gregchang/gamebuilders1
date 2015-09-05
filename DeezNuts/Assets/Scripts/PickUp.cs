using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){	//called when player gameobject touches trigger collider, arg is touched obj
		//note we aren't using OnCollisionEnter, changing collider to trigger volumes
		Debug.Log ("test");
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			
		}
	}
}
