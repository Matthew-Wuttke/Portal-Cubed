using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	
	public float scrollSpeed; //how fast to scroll
	
    //scroll the gameObject
	void Update () {
		gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0,Time.time*scrollSpeed));
	}
}
