using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.Analytics;


public class Challenge_4 : MonoBehaviour {

	public GameObject zombie;
	public Transform pos1;
	public Transform pos2;
	public GameObject door;
	public PortalEffect[] portals;
	public bool activateButton;

	float[] probab1;
	float[] probab2;

	// Use this for initialization
	void Start () {
		probab1 = new float[portals.Length];
		probab2 = new float[portals.Length];
		restProb ();
		setProbabilities ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activateButton && Input.GetKeyDown (KeyCode.E)) {
			door.GetComponent<AudioSource> ().Play ();
			door.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
            door.GetComponent<Rigidbody>().AddTorque(-Vector3.up, ForceMode.Impulse);
			GetComponentInChildren<DoorButton>().enabled = false;
			activateButton = false;
			GameObject.Find ("Button").GetComponent<Animator>().enabled = true;
			Invoke("stopAnimation",1.5f);
//			Analytics.CustomEvent("challenge4Complete", new Dictionary<string, object>{ { "dummy", 0} });
			GoogleAnalytics.Client.SendEventHit("gameFlow", "challenge4Complete");
			GoogleAnalytics.Client.SendScreenHit("challenge4Complete");
			
			
			
			
		}
	}
	void restProb(){
		float ran = Random.value;
		if (ran >= 0.5f) {
			for(int i = 0; i<portals.Length; i+=2){
				probab1[i] = portals[i].prob1;
				probab2[i] = portals[i].prob2;
				probab1[i+1] = portals[i+1].prob2;
				probab2[i+1] = portals[i+1].prob1;
			}
		} else {
			for(int i = 0; i<portals.Length; i+=2){
				probab1[i] = portals[i].prob2;
				probab2[i] = portals[i].prob1;
				probab1[i+1] = portals[i+1].prob1;
				probab2[i+1] = portals[i+1].prob2;
			}
		}
	}
	
	public void setProbabilities(){
		float ran = Random.value;
		for (int i = 0; i<portals.Length; i++) {
	
			if (ran <= probab1[i]) {
				portals[i].otherPortal = portals[i].pos1;
				portals[i].otherPortal = portals[i].pos2;
			} else {
				portals[i].otherPortal = portals[i].pos2;
				portals[i].otherPortal = portals[i].pos1;
			}
		}
	}
		void stopAnimation(){
			GameObject.Find ("Button").GetComponent<Animator> ().enabled = false;
		}
		public void incrementCounter(PortalEffect portal){
		for (int i = 0; i<portals.Length; i++) {
			if (portal == portals[i]) {
				if (portals[i].otherPortal == portals[i].pos1) {
					portals[i].counter1++;
				} else if (portals[i].otherPortal == portals[i].pos2) {
					portals[i].counter2++;
				}
			}
//			} else if (portal == portal2) {
//				if (portal2.otherPortal == pos1) {
//					counter3++;
//				} else if (portal2.otherPortal == pos2) {
//					counter4++;
//				}
//			}
			portals[i].count1.text = "" + portals[i].counter1;
			portals[i].count2.text = "" + portals[i].counter2;
//			count3.text = "" + counter3;
//			count4.text = "" + counter4;
		}
	}
	public void createZombie(int position){
		if (position == 1) {
			Instantiate (zombie, pos1.position, Quaternion.identity) ;
		} else {
			Instantiate (zombie, pos2.position, Quaternion.identity);
		}
	}
}
