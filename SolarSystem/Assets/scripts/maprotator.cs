using UnityEngine;
using System.Collections;

public class maprotator : MonoBehaviour {
	public GameObject confirm;
	public GameObject text;
	float sDistance;
	float pDistance;
	public float ratio;
	public int x;
	float r;

	// Use this for initialization
	void Start () {
		sDistance = Vector3.Magnitude (this.transform.localPosition);
		//pDistance = Vector3.Magnitude (planet.transform.localPosition);
		//ratio = sDistance / pDistance;
		x = 0;
		r = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (x == 2) {
			transform.rotation = Quaternion.Euler(transform.rotation.x, r*10f, transform.rotation.z);
			r += .2f;
		}
	}

	public void selection(){
		x = 1;
		confirm.SetActive(true);
		//confirm.reset ();
		text.SetActive(true);
	}
	public void confirmed(){
		confirm.GetComponent<confirm> ().x = 0;
		x = 2;
		confirm.SetActive (false);
		text.SetActive (false);
	}

}
