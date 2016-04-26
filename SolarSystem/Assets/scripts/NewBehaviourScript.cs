using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public Color c1 = Color.yellow;

	float x,z;

	Vector3 initial;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		initial = transform.localPosition;
	    lineRenderer= gameObject.GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		//lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.7F, 0.7F);
		lineRenderer.SetVertexCount (200);
		//lineRenderer.transform.position =new Vector3(500, 0, 0);

		int i = 0;
		float radians=0;
		for(float theta = 0f; theta < (2*Mathf.PI); theta += (2*Mathf.PI)/200)
		{
			// Calculate position of point
			float x = (500) * Mathf.Cos(theta);
			float y = (500) * Mathf.Sin(theta);

			// Set the position of this point
			Vector3 pos = new Vector3(x, 0, y);
			lineRenderer.SetPosition(i, pos);
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
