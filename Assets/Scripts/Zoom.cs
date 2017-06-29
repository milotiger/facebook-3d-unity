using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {
	public float ScaleStep = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float d = Input.GetAxis ("Mouse ScrollWheel");
		Vector3 OriginScale = transform.localScale;
		transform.localScale += new Vector3 (d * ScaleStep * OriginScale.x, d * ScaleStep * OriginScale.y, d * ScaleStep * OriginScale.z); 
	}
}
