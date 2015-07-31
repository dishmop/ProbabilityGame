using UnityEngine;
using System.Collections;

public class ColorHit_2 : MonoBehaviour {

	public Challenge_2 chanllenge2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Bullet") {
			chanllenge2.gotAShot2(GetComponent<MeshRenderer>());
			Destroy(coll.gameObject);
		}
	}
}
