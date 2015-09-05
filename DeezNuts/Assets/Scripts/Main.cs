using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject Player;
	public GameObject Bullet;
	public GameObject cam;
	public static bool shooting;
	public int bulletSpeed=10;
	Vector3 mouse= new Vector3();
	float angle;
	float tim=0;

	// Use this for initialization
	void Start () {
	
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
			Vector3 direction=Player.transform.position+Player.transform.up;
			GameObject newBullet=(GameObject) Instantiate(Bullet,direction,new Quaternion());
			direction.x=lookPos.x+cam.transform.position.x-direction.x;
			direction.y=lookPos.y+cam.transform.position.y-direction.y;
			direction.Normalize();
			newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x)*bulletSpeed,(direction.y)*bulletSpeed));
			Debug.Log("shot" + direction);
			tim=0.2f;
		}

	}
}
