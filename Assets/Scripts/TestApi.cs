using UnityEngine;
using System.Collections;

public class TestApi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("api test runs....");
		StartCoroutine (APICall.Call ("me", "photos", null, (callback)=> {
			print(callback);	
		}));
	}
}
