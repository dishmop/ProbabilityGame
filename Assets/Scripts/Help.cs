using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {
	//public Transform textPos;
	//public string instruction;
	public TextMesh instructions;

    public GameObject textpanel;

    [TextArea(3,10)]
    public string text;

	// Use this for initialization
	void Start () {
		//instructions.transform.position = textPos.position;
		//instructions.text = instruction;
		instructions.gameObject.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<MeshRenderer>().gameObject.transform.Rotate(Vector3.up, 2f);
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			//instructions.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			GetComponent<MeshRenderer>().enabled = false;

            textpanel.SetActive(true);
            textpanel.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
		}
	}
	void OnTriggerExit(Collider coll){
		if (coll.tag == "Player") {
			//instructions.gameObject.GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<MeshRenderer>().enabled = true;
            textpanel.SetActive(false);
		}
	}
}
