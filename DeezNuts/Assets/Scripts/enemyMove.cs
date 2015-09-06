using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	public GameObject Player;
	public GameObject Enemy;
	Rigidbody2D EnemyR;
	public int npoints=2;
	public static int numPoints=2;
	public int lives=3;
	public int speed=5;
	public int distance=3;
	int next=0;

	public GameObject[] w;
	
	bool follow = false;

	//Audio
	public AudioClip enemyHurt;
	AudioSource sound;
	
	// Use this for initialization
	void Start () {
		EnemyR=Enemy.GetComponent<Rigidbody2D> ();
		sound = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.name == "Bullet(Clone)") {
			lives--;
			if(lives!=0){
				sound.PlayOneShot(enemyHurt, 0.3F);
			}
			if(lives==0){
				Main.died=true;
				Destroy( this.gameObject);

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Move Enemy towards Pkayer

		float step = 3.0f * Time.deltaTime;
		if ((Vector2.Distance (Player.transform.position, Enemy.transform.position)) < distance || lives<3) {

			follow = true;


		} 

		if (follow == true) {
			Vector3 destination;
			destination = Player.transform.position - Enemy.transform.position;
			destination.Normalize ();
			EnemyR.AddForce (destination * speed);
		} else {

			if (w.Length > 1) {
				//else move in between patrol points, w1 and w2
				transform.position = Vector3.MoveTowards (transform.position, w [next].transform.position, step);
				Vector3 destination;
				destination = Enemy.transform.position - w[next].transform.position;
				float angle =  Mathf.Atan2(destination.y, destination.x) * Mathf.Rad2Deg;
				Enemy.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
				//Debug.Log (transform.position + " " + w1.transform.position);

				if (transform.position.ToString ().Equals (w [next].transform.position.ToString ())) {
					next++;
					if (next >= w.Length) {
						next = 0;
					}
					//Debug.Log ("works");
				}
			}
		}
	}
}

