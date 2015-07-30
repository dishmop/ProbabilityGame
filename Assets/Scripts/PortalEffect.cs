using UnityEngine;
using System.Collections;

public class PortalEffect : MonoBehaviour {
	public Transform otherPortal;
	public Transform currentPortal;
	public Challenge_1 chanllenge1;
	public bool isChosen;
	public TextMesh text;

	int bulletCount;

	// Use this for initialization
	void Start () {
		currentPortal = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider coll){
		if (text != null) {
			bulletCount++;
			text.text = ""+ bulletCount;
		}
		if (chanllenge1 != null && isChosen) {
			chanllenge1.incrementCount();
			Destroy(coll.gameObject);
			isChosen = false;
			return;
		}
		Vector3 velocity = coll.GetComponent<Destoryer> ().bulletVelocity;
		//Debug.Log ("Before " + coll.GetComponent<Rigidbody> ().velocity.ToString());  
		float speed = velocity.magnitude;
		velocity = Vector3.Reflect (velocity, currentPortal.forward);
		velocity = currentPortal.InverseTransformDirection (velocity);
		velocity = otherPortal.TransformDirection (velocity);
		coll.GetComponent<Rigidbody> ().velocity = speed * velocity.normalized;
		//Debug.Log ("After" + coll.GetComponent<Rigidbody> ().velocity.ToString()); 
		//Vector3 pos  = currentPortal.position - coll.transform.position;
		//pos = Vector3.Reflect(pos, currentPortal.forward);
		//pos = currentPortal.InverseTransformDirection(pos);
		//pos = otherPortal.TransformDirection(pos);
		//pos += otherPortal.position;
		coll.transform.position = otherPortal.position;
		coll.GetComponent<Rigidbody> ().AddForce (25f * otherPortal.forward, ForceMode.Impulse);
		if (chanllenge1 != null) {
			chanllenge1.restProbabilities ();
		}
	}
}
