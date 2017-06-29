using UnityEngine;
using System.Collections;

public class Helper{
	public static Transform getChildByTag(string Tag, GameObject parent)
	{
		foreach(Transform t in parent.transform)
		{
			if (t.tag == Tag)
				return t;
		}
		return null;
	}

	public static void setTextureToObject(Transform obj, Texture tex, bool upSideDown = false)
	{
		obj.GetComponent<Renderer>().material.mainTexture = tex;
		if (!upSideDown)
			obj.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));
		else
			obj.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(1, -1));
			
	}

	public static Texture getLCDTexture(GameObject LCD)
	{
		return getChildByTag ("LCD_Main", LCD).GetComponent<Renderer> ().material.GetTexture ("_MainTex");
	}

	public static void setLCDVisibility(GameObject LCD, bool isEnabled)
	{
		getChildByTag ("LCD_Main", LCD).GetComponent<MeshRenderer> ().enabled = isEnabled;
		getChildByTag ("LCD_Holder", LCD).GetComponent<MeshRenderer> ().enabled = isEnabled;
	}

	public static void changeAspectRatio(GameObject parent, float scaleY)
	{	
		float originScaleY = parent.transform.localScale.y;
		parent.transform.localScale += new Vector3 (0, scaleY * originScaleY - originScaleY, 0);
		if (parent.GetComponent<MoveToPosition> () != null)
			parent.GetComponent<MoveToPosition> ().UpdateScale (parent.transform.localScale);
	}

	public static void resetAspectRatio(GameObject parent)
	{
		float originScaleZ = parent.transform.localScale.z;
		parent.transform.localScale = Vector3.one * originScaleZ;
	}
}
