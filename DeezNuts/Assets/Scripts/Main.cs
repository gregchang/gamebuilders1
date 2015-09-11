using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject Player;
	public GameObject Bullet;
	public GameObject cam;
	public GameObject Nut;
	public GameObject[] points=new GameObject[10];
	public static bool shooting;
	public int bulletSpeed=10;
	public static int deez=10;
	public static float bullet_time = 0.2f;
	public static bool died=false;
	public string Scene;
	Vector3 mouse= new Vector3();
	float angle;
	float tim=0;

	//Audio
	public AudioClip enemyDeath;
	AudioSource sound;

	// Use this for initialization
	void Start () {
		deez = points.Length;
		for (int i=0; i<points.Length; i++) {
			Instantiate (Nut, points[i].transform.position, new Quaternion());
		}
		sound = GetComponent<AudioSource> ();

	
	}

	// Update is called once per frame
	void Update () {

		mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mouse);
		lookPos = lookPos - Player.transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		Player.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

		//Bullet.transform.position = new Vector3(lookPos.x+cam.transform.position.x, lookPos.y+cam.transform.position.y, 0);
		//front.transform.position = Player.transform.position + Player.transform.up;
		
		tim -= Time.deltaTime;
		if (shooting && tim<0) {
			Vector3 direction=Player.transform.position;
			GameObject newBullet=(GameObject) Instantiate(Bullet,direction,new Quaternion());
			direction.x=lookPos.x+cam.transform.position.x-direction.x;
			direction.y=lookPos.y+cam.transform.position.y-direction.y;
			direction.Normalize();
			newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x)*bulletSpeed,(direction.y)*bulletSpeed));
			Debug.Log("shot" + direction);
			tim=bullet_time;
		}
		if (died) {
			sound.PlayOneShot(enemyDeath, 0.3F);
			died=false;
		}

	}
}
