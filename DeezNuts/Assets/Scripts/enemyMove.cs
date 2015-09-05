using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	public GameObject Player;
	Rigidbody2D PlayerR;
	public GameObject Enemy;
	Rigidbody2D EnemyR;

	public GameObject w1;
	public GameObject w2;

	bool switch1 = false;
	bool follow = false;
	
	// Use this for initialization
	void Start () {
		PlayerR=Player.GetComponent<Rigidbody2D> ();
		EnemyR=Enemy.GetComponent<Rigidbody2D> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerR.velocity.y<10 && PlayerR.velocity.y>-10) {
		PlayerR.AddForce(new Vector2(0,Input.GetAxis ("Vertical")*10));

		}
		if (PlayerR.velocity.x<10 && PlayerR.velocity.x>-10) {
			PlayerR.AddForce(new Vector2(Input.GetAxis ("Horizontal")*10,0));
		}


		// Move Enemy towards Pkayer


		float step = 3.0f * Time.deltaTime;
		if ((Vector2.Distance (GameObject.Find ("Player").transform.position, GameObject.Find ("Enemy").transform.position)) < 5) {

			follow = true;


		} 

		if (follow == true) {
			transform.position = Vector3.MoveTowards (transform.position, PlayerR.transform.position, step);
		}
		else {
			if (!switch1) {
				//else move in between patrol points, w1 and w2

				transform.position = Vector3.MoveTowards (transform.position, GameObject.Find ("w1").transform.position, step);
				//Debug.Log (transform.position + " " + w1.transform.position);

				if (transform.position.ToString ().Equals (w1.transform.position.ToString ())) {
					switch1 = true;
					Debug.Log ("works");
				}

			} else { //switch1 is true

				transform.position = Vector3.MoveTowards (transform.position, GameObject.Find ("w2").transform.position, step);
			
				if (transform.position.ToString ().Equals (w2.transform.position.ToString ())) {
					switch1 = false;
				}

			}
		}
	}
}
