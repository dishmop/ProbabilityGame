using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour {

	public Challenge_3 challenge3;
	public Challenge_4 challenge4;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			if (challenge3 != null) {
				challenge3.activateButton = true;
			} else if (challenge4 != null) {
				challenge4.activateButton = true;
			}
		}
	}
	void OnTriggerExist(Collider coll){
		if (coll.tag == "Player") {
			if (challenge3 != null) {
				challenge3.activateButton = false;
			} else if (challenge4 != null) {
				challenge4.activateButton = false;
			}
		}
	}
}
