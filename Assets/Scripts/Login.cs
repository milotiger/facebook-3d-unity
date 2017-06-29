using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!FB.IsInitialized)
		{
			// Initialize the Facebook SDK
			FB.Init(this.InitCallback, this.OnHideUnity);
			Debug.Log("FBInit is called with appID:" + FB.AppId);
		}
		else
		{
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	public void LoginCallback(ILoginResult result)
	{
		if (FB.IsLoggedIn) {
			print ("Login successfull");
			print (result);
			Debug.Log (Facebook.Unity.AccessToken.CurrentAccessToken.TokenString);
			Global.access_token = Facebook.Unity.AccessToken.CurrentAccessToken.TokenString;
			SceneManager.LoadScene ("Demo2");
		} else {
			print ("log in fail!");
		}
	}

	private void InitCallback()
	{
		if (FB.IsInitialized)
		{
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
			var perms = new List<string>() { "public_profile", "email", "user_friends", "user_photos"};
			FB.LogInWithReadPermissions(perms, LoginCallback);
		}
		else
		{
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}


	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

}
