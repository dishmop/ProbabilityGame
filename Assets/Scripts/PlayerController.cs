using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public BoxCollider[] portals;
	public GameObject bullet;
	public float bulletSpeed = 50f;
	public float timeBetweenShots = 0.5f;

	int bulletCount;
	float timer;
	// Use this for initialization
	void Start () {
		portals = GetComponent<Randomness> ().portals;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && timer >= timeBetweenShots) {
			shoot();
		}
		if (Input.GetMouseButtonDown (1)) {
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	void shoot(){
		bulletCount++;
		GameObject bullet1 = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
		bullet1.GetComponent<Rigidbody> ().AddForce (bulletSpeed * transform.forward, ForceMode.Impulse);
		foreach (BoxCollider portal in portals) {
			portal.enabled = false;
		}
		GetComponent<Randomness> ().changePro ();
	}
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,50), "Bullet counter");
		GUI.TextField (new Rect (20, 30, 40, 20), "" + bulletCount);
	}
}