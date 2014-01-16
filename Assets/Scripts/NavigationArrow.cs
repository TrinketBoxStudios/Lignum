using UnityEngine;
using System.Collections;

public class NavigationArrow : MonoBehaviour {

	public float fadeTime = 1.0f;
	public string levelToLoad = "none";

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		Application.LoadLevel(levelToLoad);
	}
}
