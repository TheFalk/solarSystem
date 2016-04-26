using UnityEngine;
using System.Collections;

public class droneController : MonoBehaviour {

	public float radians;
	public float angle;
	public float radius;
	public float speed;
	private float tempx;
	private float tempz;
	private float direction;
	private float yrotation;

	void Start () {
		radians =0;
		speed=(2*Mathf.PI)/5;
		radius=5;
		yrotation = transform.rotation.y;
	}

	void Update()
	{
		radians += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
		angle = radians*180/Mathf.PI;
		tempz = Mathf.Cos (radians) * radius;
		tempx = Mathf.Sin (radians) * radius;
		transform.position = new Vector3(tempx, transform.position.y, tempz );
		transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
	}
	// Update is called once per frame

}
