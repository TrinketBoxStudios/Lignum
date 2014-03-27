using UnityEngine;
using System.Collections;

public class ResumeButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}

	void OnMouseDown()
	{
		SendMessageUpwards("ResumeGame");
	}
}
