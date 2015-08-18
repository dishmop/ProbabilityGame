using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {
	//public Transform textPos;
	//public string instruction;
	public TextMesh instructions;
	// Use this for initialization
	void Start () {
		//instructions.transform.position = textPos.position;
		//instructions.text = instruction;
		instructions.gameObject.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			instructions.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			GetComponent<MeshRenderer>().enabled = false;
		}
	}
	void OnTriggerExit(Collider coll){
		if (coll.tag == "Player") {
			instructions.gameObject.GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
