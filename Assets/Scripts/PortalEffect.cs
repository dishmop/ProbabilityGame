using UnityEngine;
using System.Collections;

public class PortalEffect : MonoBehaviour {
	public Transform otherPortal;
	public Transform currentPortal;
	public Challenge_1 chanllenge1;
	public TextMesh text;
	public Challenge_3 challenge3;
	public Challenge_4 challenge4;
	public float prob1 = 0.3f;
	public float prob2 = 0.7f;
	public Transform pos1;
	public Transform pos2;
	public TextMesh count1;
	public TextMesh count2;
	public int counter1;
	public int counter2;
	public Transform zombiePos1;
	public Transform zombiePos2;
	int bulletCount;

    public int i;

	// Use this for initialization
	void Start () {
		currentPortal = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Bullet" || coll.tag == "Player") {
			if (text != null) {
				bulletCount++;
				text.text = ""+ bulletCount;
			}
			if (chanllenge1 != null) {
                if(chanllenge1.firstcolour == i)
                {
                    chanllenge1.firstcolour = -1;
                    chanllenge1.incrementCount();
                }
                else if (chanllenge1.secondcolour == i)
                {
                    chanllenge1.secondcolour = -1;
                    chanllenge1.incrementCount();
                }
                else
                {
                    chanllenge1.resetProbabilities();

                }
				//chanllenge1.incrementCount();
				Destroy(coll.gameObject);
				return;
			}
			Vector3 velocity;
			if(coll.tag == "Bullet"){
				velocity = coll.GetComponent<Destoryer> ().bulletVelocity;
			}else{
				velocity = coll.GetComponent<Rigidbody>().velocity;
			}

			//Debug.Log ("Before " + coll.GetComponent<Rigidbody> ().velocity.ToString());  
			float speed = velocity.magnitude;
			velocity = Vector3.Reflect (velocity, currentPortal.forward);
			velocity = currentPortal.InverseTransformDirection (velocity);

			coll.GetComponent<Rigidbody> ().velocity = speed * velocity.normalized;
			//Debug.Log ("After" + coll.GetComponent<Rigidbody> ().velocity.ToString()); 
			//Vector3 pos  = currentPortal.position - coll.transform.position;
			//pos = Vector3.Reflect(pos, currentPortal.forward);
			//pos = currentPortal.InverseTransformDirection(pos);
			//pos = otherPortal.TransformDirection(pos);
			//pos += otherPortal.position;
            if (otherPortal != null)
            {
                coll.transform.position = otherPortal.position;
                velocity = otherPortal.TransformDirection(velocity);
                coll.GetComponent<Rigidbody>().AddForce(25f * otherPortal.forward, ForceMode.Impulse);
            }
            else
            {
                Destroy(coll.gameObject);
            }
			
			if(challenge3 != null){
				challenge3.incrementCounter(this);
				challenge3.setProbabilities();
			}
			if(challenge4 != null){
				challenge4.incrementCounter(this);
				challenge4.setProbabilities();
				if(otherPortal == zombiePos1){
					challenge4.createZombie(1);
				} else if(otherPortal == zombiePos2){
					challenge4.createZombie(2);
				}
			}
		}
	}
}
