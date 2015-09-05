using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public GameObject Player;
	Rigidbody2D PlayerR;

	// Use this for initialization
	void Start () {
		PlayerR=Player.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerR.velocity.y<10 && PlayerR.velocity.y>-10) {
			PlayerR.AddForce(new Vector2(0,Input.GetAxis ("Vertical")*10));
		}
		if (PlayerR.velocity.x<10 && PlayerR.velocity.x>-10) {
			PlayerR.AddForce(new Vector2(Input.GetAxis ("Horizontal")*10,0));
		}
	
	}


}
