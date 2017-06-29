using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float Duration = 1f;
	private float Alpha = 0;

	// Use this for initialization
	void Start () {
		//GetComponent<Renderer> ().material.color = new Color(1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		FadeInObject ();
	}

	void FadeInObject() {
		var Lerp = Mathf.PingPong (Time.time, Duration) / Duration;
		Alpha = Mathf.Lerp (1.0f, 0.0f, Lerp);
		print (Alpha);
		var CurrentColor = GetComponent<Renderer> ().material.color;
		CurrentColor.a = Alpha;
		GetComponent<Renderer> ().material.color = CurrentColor;
		print (GetComponent<Renderer> ().material.color);
	}
}
