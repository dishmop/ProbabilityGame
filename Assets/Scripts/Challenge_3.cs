using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.Analytics;

public class Challenge_3 : MonoBehaviour {

	public float prob1 = 0.3f;
	public float prob2 = 0.7f;
	public GameObject door;
	public PortalEffect portal1;
	public PortalEffect portal2;
	public Transform pos1;
	public Transform pos2;
	public bool activateButton;
	public TextMesh count1;
	public TextMesh count2;
	public TextMesh count3;
	public TextMesh count4;
	int counter1;
	int counter2;
	int counter3;
	int counter4;

//	float probab1;
//	float probab2;
	// Use this for initialization
	void Start () {
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
			GameObject.Find ("Button1").GetComponent<Animator>().enabled = true;
			Invoke("stopAnimation",1.5f);
//			Analytics.CustomEvent("challenge3Complete", new Dictionary<string, object>{ { "dummy", 0} });
			GoogleAnalytics.Client.SendEventHit("gameFlow", "challenge3Complete");
			GoogleAnalytics.Client.SendScreenHit("challenge3Complete");
			
			
			

		}
	
	}

	void restProb(){
		float ran = Random.value;
		if (ran >= 0.5f) {
//			probab1 = prob1;
//			probab2 = prob2;
		} else {
//			probab1 = prob2;
//			probab2 = prob1;
		}
	}

	public void setProbabilities(){
		float ran = Random.value;
		if (ran <= prob1) {
			portal1.otherPortal = pos1;
			portal2.otherPortal = pos2;
		} else {
			portal1.otherPortal = pos2;
			portal2.otherPortal = pos1;
		}

//		if (ran <= prob2) {
//			portal2.otherPortal = pos1;
//		} else {
//			portal2.otherPortal = pos2;
//		}
	}
	void stopAnimation(){
		GameObject.Find ("Button1").GetComponent<Animator> ().enabled = false;
	}
	public void incrementCounter(PortalEffect portal){
		//totcounter++;
		if (portal == portal1) {
			if(portal1.otherPortal == pos1){
				counter1++;
			}else if(portal1.otherPortal == pos2){
				counter2++;
			}

		}else if (portal == portal2){
			if(portal2.otherPortal == pos1){
				counter3++;
			}else if(portal2.otherPortal == pos2){
				counter4++;
			}

		}
		count1.text = "" + counter1;
		count2.text = "" + counter2;
		count3.text = "" + counter3;
		count4.text = "" + counter4;
	}
}
