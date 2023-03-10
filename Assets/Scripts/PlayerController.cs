using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int pos;
	public BoxCollider[] portals;
	public GameObject bullet;
	public float bulletSpeed = 50f;
	public float timeBetweenShots = 0.5f;
	public int bulletCount = 100;

    public GameObject creditspanel;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsc;

	float timer;
	// Use this for initialization
	void Start () {
		portals = GetComponent<Randomness> ().portals;
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && timer >= timeBetweenShots && bulletCount > 0) {
			shoot();
		}
		if (Input.GetMouseButtonDown (1)) {
			Cursor.lockState = CursorLockMode.Locked;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
            creditspanel.SetActive(true);
            fpsc.enabled = false;
		}

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
	}

	void shoot(){
		bulletCount--;
		GameObject bullet1 = Instantiate (bullet, Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,1f)), transform.rotation) as GameObject;
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