using UnityEngine;
using System.Collections;

public class HideAtStarting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var CurrentColor = GetComponent<Renderer> ().material.color;
		CurrentColor.a = 0;
		GetComponent<Renderer> ().material.color = CurrentColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
