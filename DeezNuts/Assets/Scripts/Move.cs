using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public GameObject Player;
	public GameObject End;
	public GameObject Fin;
	public string thisS;
	public string nextS;
	string endS;
	bool show=false;
	Rigidbody2D PlayerR;
	public int lives = 1;

	// Use this for initialization
	void Start () {
		PlayerR=Player.GetComponent<Rigidbody2D> ();
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Inside Move Trigger");
		if (other.name == "Nut(Clone)") {
			Main.deez--;
		}
<<<<<<< HEAD
		if (other.gameObject.tag == "PickUp") {
			if(Main.bullet_time >= 0.12f){
				Debug.Log("Faster shooting!");
				Main.bullet_time -= 0.02f;
			}
			else
				Debug.Log ("Already at 0.10f delay.");
=======
		if (other.name == "Damage") {
			lives--;
>>>>>>> origin/master
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (lives > 0 && Main.deez > 0) {
			if (PlayerR.velocity.y < 10 && PlayerR.velocity.y > -10) {
				PlayerR.AddForce (new Vector2 (0, Input.GetAxis ("Vertical") * 20));
			}
			if (PlayerR.velocity.x < 10 && PlayerR.velocity.x > -10) {
				PlayerR.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * 20, 0));
			}
		} else {
			if(lives<=0){
				endS=thisS;
				End.transform.position=Player.transform.position;
			}
			if(Main.deez<=0){
				endS=nextS;
				Fin.transform.position=Player.transform.position;
			}
			if(Input.GetKeyDown("space")){
				Application.LoadLevel(endS);
			}
		}


	
	}


}
