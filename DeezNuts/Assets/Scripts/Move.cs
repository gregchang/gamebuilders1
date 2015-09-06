using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public GameObject Player;
	Rigidbody2D PlayerR;

	// Use this for initialization
	void Start () {
		PlayerR=Player.GetComponent<Rigidbody2D> ();
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Inside Move Trigger");
		if (other.name == "Nut(Clone)") {
			Main.deez--;
		}
		if (other.gameObject.tag == "PickUp") {
			if(Main.bullet_time >= 0.12f){
				Debug.Log("Faster shooting!");
				Main.bullet_time -= 0.02f;
			}
			else
				Debug.Log ("Already at 0.10f delay.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerR.velocity.y<10 && PlayerR.velocity.y>-10) {
			PlayerR.AddForce(new Vector2(0,Input.GetAxis ("Vertical")*20));
		}
		if (PlayerR.velocity.x<10 && PlayerR.velocity.x>-10) {
			PlayerR.AddForce(new Vector2(Input.GetAxis ("Horizontal")*20,0));
		}
	
	}


}
