using UnityEngine;
using System.Collections;

public class confirm : MonoBehaviour {
	public int x;
	// Use this for initialization
	void Start () {
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void confirming(GameObject target){
		x = 1;
		target.GetComponent<maprotator> ().confirmed ();
	}
}
