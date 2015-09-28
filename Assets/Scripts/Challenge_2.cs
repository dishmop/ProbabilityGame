using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Challenge_2 : MonoBehaviour {

	public MeshRenderer[] materials;
	public MeshRenderer changeColor;
	public float[] probs;
	public GameObject door1;
	public GameObject door2;
	public AudioClip failSound;
	public AudioClip succeedSound;
	public TextMesh text;
	public TextMesh[] texts;

	public MeshRenderer[] materials_t;
	int counter;
	int[] counters;
	int count;
	bool gotFirstMaterial;
	bool gotSecondMaterial;
	// Use this for initialization
	void Start () {
		materials_t = (MeshRenderer[]) materials.Clone();
		counters = new int[materials.Length];

        setProbabilities();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setProbabilities(){
		List<MeshRenderer> source = new List<MeshRenderer> (materials);
		source.Shuffle ();
		materials = source.ToArray ();
	}

	public void gotAShot1(MeshRenderer mesh){
		if (mesh.material == materials [0].material) {
			door1.GetComponent<AudioSource> ().Play ();
			door1.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
            door1.GetComponent<Rigidbody>().AddTorque(-Vector3.up, ForceMode.Impulse);
		} else {
			setProbabilities();
			for( int i = 0; i<counters.Length; i++){
				counters[i] = 0;
				texts[i].text = ""+counters[i];
			}
			counter = 0;
			text.text = "" + counter;
			GetComponent<AudioSource>().clip = null;
			GetComponent<AudioSource>().clip = failSound;
			GetComponent<AudioSource>().Play();

		}
	}
	public void gotAShot2(MeshRenderer mesh){
		if (mesh.material.color == materials [0].material.color && !gotFirstMaterial) {
			gotFirstMaterial = true;
			count++;
			GetComponent<AudioSource>().clip = null;
			GetComponent<AudioSource>().clip = succeedSound;
			GetComponent<AudioSource>().Play();


		} else if (mesh.material.color == materials [1].material.color && !gotSecondMaterial) {
			gotSecondMaterial = true;
			count++;
			GetComponent<AudioSource>().clip = null;
			GetComponent<AudioSource>().clip = succeedSound;
			GetComponent<AudioSource>().Play();

		} else {
			setProbabilities();
			for( int i = 0; i<counters.Length; i++){
				counters[i] = 0;
				texts[i].text = ""+counters[i];
			}
			counter = 0;
			text.text = "" + counter;
			GetComponent<AudioSource>().clip = null;
			GetComponent<AudioSource>().clip = failSound;
			GetComponent<AudioSource>().Play();

		}
		if(count ==2){
			count = 0;
			GetComponent<AudioSource>().Stop();
			door2.GetComponent<AudioSource> ().Play ();
			door2.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
            door2.GetComponent<Rigidbody>().AddTorque(-Vector3.up, ForceMode.Impulse);
		}
	}

	public void onHit(){
		counter++;
		text.text = "" + counter;
		float randomnum = Random.value;

        float cumulativeprob = 0.0f;

		for (int i = 0; i<materials.Length; i++) {
            cumulativeprob += probs[i];

            if (cumulativeprob > randomnum)
            {
                changeColor.material = materials[i].material;
				incrementColor(materials[i].material);
                break;
            }
		}
	}

	void incrementColor(Material mat){
		for (int i = 0; i < materials.Length; i++) {
			if(mat == materials_t[i].material){
				counters[i]++;
				texts[i].text = ""+counters[i];
			}
		}
	}

}
public static class Extension{
	public static void Shuffle<T>(this List<T> list) {

        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[j];
            list[j] = list[i];
            list[i] = temp;
        }
	}
}