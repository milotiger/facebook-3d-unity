using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class APICall {
	public static IEnumerator Call (string UserID, string Edge, List<Query> Queries, System.Action<string> DataString)
	{
		Debug.Log ("call runs.....");
		string url = Global.baseApi;
		url += UserID + "/photos";
		url += "?access_token=" + Global.access_token + "&fields=name,images&limit=100&type=uploaded";// + "&fields=photos.limit(100){images, name}";

		Debug.Log (url);
		if (Queries != null && Queries.Count > 0) {
			foreach (Query query in Queries) {
				url += "&" + query.key + "=" + query.value;
			}
		}

		WWW www = new WWW(url);

		yield return www;

		//Debug.Log (www.text);
		DataString (www.text);
	}
}