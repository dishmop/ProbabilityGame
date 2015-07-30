using UnityEngine;
using System.Collections;

public class Randomness : MonoBehaviour {

	public BoxCollider[] portals;
	public float[] probs;
	public float rand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changePro(){
		float num = Random.value;
		rand = num;
		float ini = 0f;
		for (int i = 0; i<portals.Length; i++) {
			if ((probs [i] + ini) >= num) {
					portals[i].enabled  = true;
				break;
			}else{
				ini += probs[i];
			}
		}
	}
}
