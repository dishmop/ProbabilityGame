using UnityEngine;
using System.Collections;

public class Challenge_1 : MonoBehaviour {

	public PortalEffect[] portals;
	public float[] probabs;

	private int count;
	public AudioClip[] sounds;

    public int firstcolour = -1;
    public int secondcolour = -1;


	// Use this for initialization
	void Start () {
		resetProbabilities ();

        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].i = i;
        }
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

		count = 0;

        float cumulativeprob = 0f;

        float random1 = Random.value;
        float random2 = Random.value;

        firstcolour = -1;
        secondcolour = -1;


		for(int i = 0; i < portals.Length; i++) {
            cumulativeprob += probabs[i];

            if (firstcolour == -1 && random1 < cumulativeprob)
            {
                firstcolour = i;
            }

            if (secondcolour == -1 && random2 < cumulativeprob)
            {
                secondcolour = i;
            }
		}
	}
}
