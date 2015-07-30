using UnityEngine;
using System.Collections;



public class Destoryer : MonoBehaviour {

	public float timeToDestory = 10f;
	public Vector3 bulletVelocity;

	bool takeSpeed;
	// Use this for initialization
	void Start () {
		Invoke ("destory", timeToDestory);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!takeSpeed && GetComponent<Rigidbody> ().velocity.z > 10f) {
			bulletVelocity = GetComponent<Rigidbody> ().velocity;
			takeSpeed = true;
		}

	}
	void destory(){
		Destroy(gameObject);
	}
}
