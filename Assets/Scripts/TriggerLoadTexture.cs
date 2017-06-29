using UnityEngine;
using System.Collections;

public class TriggerLoadTexture : MonoBehaviour {
	Texture originTexture;
	bool isTrigged = false;
	// Use this for initialization
	void Start () {
		originTexture = GetComponent<Renderer> ().material.GetTexture ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isTrigged && GetComponent<Renderer> ().material.GetTexture ("_MainTex") != originTexture) {
			Debug.Log ("got it!");
			isTrigged = true;
		}
	}

	public bool isLoadDone()
	{
		return isTrigged;
	}

	public void Reset()
	{
		isTrigged = false;
	}
}
