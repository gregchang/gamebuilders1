using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PickUp : MonoBehaviour {

	public AudioClip cashier;
	public AudioClip chomp;
	AudioSource sound;

	void Start() {
		sound = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other){	//called when player gameobject touches trigger collider, arg is touched obj
		//note we aren't using OnCollisionEnter, changing collider to trigger volumes
		//Debug.Log ("test");
		switch (other.name) {
		case "Nut(Clone)":
			sound.PlayOneShot (chomp, 1F);
			break;
		case "deeze_diamonds":
			sound.PlayOneShot (cashier, 0.1F);
			break;
		}
		Debug.Log("deez");
	}
}
