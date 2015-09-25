using UnityEngine;
using System.Collections;

public class Challenge_1 : MonoBehaviour {

	public PortalEffect[] portals;
	public float[] probabs;
	public float rand;
	private int count;
	public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
		resetProbabilities ();
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 2) {
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			count = -1;
		}
	}
	public void incrementCount(){
		GetComponent<AudioSource>().PlayOneShot(sounds[2]);
		this.count++;
	}

	public void resetProbabilities(){
		GetComponent<AudioSource>().PlayOneShot(sounds[1]);
		foreach (PortalEffect portal in portals) {
			portal.isChosen = false;
		}
		count = 0;
		rand = Random.value;
		//int first = -1;
		for(int i = 0; i < portals.Length; i++) {
//			if(first == i){
//				continue;
//			}
			if(Random.value <= probabs[i]){
				portals[i].isChosen = true;
//				first = i;
//				count++;
//				if(count == 2){
//					count = 0;
//					return;
//				}
			}
		}
//		restProbabilities ();
	}
}
