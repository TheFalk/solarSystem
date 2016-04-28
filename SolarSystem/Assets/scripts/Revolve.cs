using UnityEngine;
using System.Collections;

public class Revolve : MonoBehaviour {
	GameObject[] planets;
	float[] x;
	float[] z;
	float[] radians;
	float[] a={1f,2f,3f,4f,5f,6f,7f,8f,9f};
	float[] b={1.5f,2.5f,3.5f,4.5f,5.5f,6.5f,7.5f,8.5f,9.5f};
	float[] speed={1f,.9f,.8f,.7f,.6f,.5f,.4f,.3f,.2f,.1f};
	float[] radius;
	float angle;
	int numPoints=500;
	//float[] initialx,initialz;

	// Use this for initialization
	void Start () {
		int len = transform.childCount;
		x=new float[len];
		z=new float[len];
		radians=new float[len];
		radius=new float[len];
	
		planets = new GameObject[len];
		for (int i=0; i < len; i++) {
			planets [i] = transform.GetChild (i).gameObject;
			radius[i]=Vector3.Distance(transform.position,planets[i].transform.position);
		}

		//lineRenderer.useWorldSpace =false;
		//lineRenderer.transform.position =new Vector3(500, 0, 0);
		for (int i=0; i < len; i++) {
			
			radius[i]=Vector3.Distance(transform.position,planets[i].transform.position);
			int j = 0;
			Debug.Log (radius[i]+"d"+planets[i].transform.position);
			for(float theta = 0f; theta <= (2*Mathf.PI); theta += (2*Mathf.PI)/numPoints)
			{
				// Set the position of this point
				Vector3 pos = new Vector3((radius[i]) * Mathf.Cos(theta), 0, (radius[i]) * Mathf.Sin(theta));
				j++;
			}
		}

	}

	// Update is called once per frame
	void Update () {
	
		for (int i = 0 ; i < planets.Length; i++) {
			radians[i] += speed[i] * Time.deltaTime;
			angle = radians[i]*180/Mathf.PI;
			//z[i] = Mathf.Cos (radians[i]) * a[i];
			//x[i] = Mathf.Sin (radians[i]) * b[i];
			z[i] = Mathf.Cos (radians[i]) * radius[i];
			x[i] = Mathf.Sin (radians[i]) * radius[i];
			planets[i].transform.position = new Vector3 (x[i], planets[i].transform.position.y, z[i]);
			//Debug.Log (radians[i]+" "+planets[i]+speed[i]);
			planets[i].transform.rotation = Quaternion.Euler(planets[i].transform.rotation.x, angle*speed[i]*10f, planets[i].transform.rotation.z);

		}
	}
}
