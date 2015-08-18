using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public int bulletDamage = 5;
	public float waitingTime = 3f;
	enum states {findingTarget, moving, attacking, waiting};
	states state;
	GameObject target;
	float timer;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		state = states.findingTarget;
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
		case states.findingTarget:
			findTarget();
			break;
		case states.moving:
			move();
			break;
		case states.attacking:
			reachTarget(target);
			break;
		case states.waiting:
			timer += Time.deltaTime;
			if(timer >= waitingTime){
				timer = 0f;
				state = states.findingTarget;
			}
			break;
		}
	
	}
	void findTarget(){
		target = GameObject.FindGameObjectWithTag("Bullet");
		if (target == null) {
			target = GameObject.FindGameObjectWithTag("Player");
		}
		if (target != null) {
			state = states.moving;
		}

	}
	void move(){
		if (target != null) {
			agent.SetDestination (target.transform.position);
			agent.Resume ();
			GetComponent<Animator> ().SetFloat ("Speed", agent.speed);
		} else {
			state = states.waiting;
		}

	}
	void reachTarget(GameObject target){
		if (target.tag == "Player") {
			target.GetComponentInChildren<PlayerController> ().bulletCount -= bulletDamage;
			if (target.GetComponentInChildren<PlayerController> ().bulletCount < 0) {
				target.GetComponentInChildren<PlayerController> ().bulletCount = 0;
			}
			Destroy(gameObject);

			return;
		} else if (target.tag == "Bullet") {
			agent.Stop();
			GetComponent<Animator> ().SetFloat ("Speed", 0f);
			Destroy(target);
			target = null;
		}
		state = states.waiting;
	}
	void OnTriggerEnter(Collider coll){
		this.target = coll.gameObject;
		state = states.attacking;
	}
}
