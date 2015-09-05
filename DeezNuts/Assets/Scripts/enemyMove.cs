using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	public GameObject Player;
	Rigidbody2D PlayerR;
	public GameObject Enemy;
	Rigidbody2D EnemyR;
	public static int numPoints=2;
	public int lives=3;
	public int speed=5;
	int next=0;

	public GameObject[] w= new GameObject[numPoints];

	bool switch1 = false;
	bool follow = false;
	
	// Use this for initialization
	void Start () {
		PlayerR=Player.GetComponent<Rigidbody2D> ();
		EnemyR=Enemy.GetComponent<Rigidbody2D> ();

		
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.name == "Bullet(Clone)") {
			lives--;
			if(lives==0){
				Destroy( this.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Move Enemy towards Pkayer


		float step = 3.0f * Time.deltaTime;
		if ((Vector2.Distance (Player.transform.position, Enemy.transform.position)) < 5) {

			follow = true;


		} 

		if (follow == true) {
			Vector3 destination;
			destination=Player.transform.position-Enemy.transform.position;
			destination.Normalize();
			EnemyR.AddForce(destination*speed);
		} else {
			//else move in between patrol points, w1 and w2
			transform.position = Vector3.MoveTowards (transform.position, w[next].transform.position, step);
			//Debug.Log (transform.position + " " + w1.transform.position);

			if (transform.position.ToString ().Equals (w [next].transform.position.ToString ())) {
				switch1 = true;
				next++;
				if(next>=numPoints){
					next=0;
				}
				Debug.Log ("works");
			}
		}
	}
}
