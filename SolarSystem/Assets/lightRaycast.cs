using UnityEngine;
using System.Collections;

public class lightRaycast : MonoBehaviour {
	GameObject target;
	public GameObject otherLight;
	GameObject temp;
	int targetInt;
	// Use this for initialization
	Ray lightRay;
	void Start () {
		lightRay = new Ray ();
		targetInt = 0;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		lightRay = new Ray (transform.position, transform.position - otherLight.transform.position);
		if(Physics.Raycast(lightRay, out hit, Mathf.Infinity)){
			if (hit.collider != null) {
				//Debug.Log ("Something was hit");
				Debug.Log("raycast");
				//
				if(hit.collider.tag == "mapPlanet"){
					Debug.Log("raycast hit");

					target = hit.collider.gameObject;
					if (target.GetComponent<maprotator> ().x == 0) {
						target.GetComponent<maprotator> ().selection();
						temp = target;
					}
					//if (iTarget.GetComponent<Event Target Behavior> ()) {
						
					//}
				}
				if(hit.collider.tag == "confirm"){
					Debug.Log("confirm hit");

					target = hit.collider.gameObject;
					if (target.GetComponent<confirm> ().x == 0) {
						target.GetComponent<confirm> ().confirming(temp);
					}

				}
			}
		}
	}
}
