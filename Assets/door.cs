using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

    public GameObject textpanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (GetComponent<Rigidbody>().constraints != RigidbodyConstraints.None)
            {
                textpanel.SetActive(true);
                textpanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "Door locked";
            }
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            textpanel.SetActive(false);
        }
    }
}
