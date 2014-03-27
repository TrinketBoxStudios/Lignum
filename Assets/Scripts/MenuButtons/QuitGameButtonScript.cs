using UnityEngine;
using System.Collections;

public class QuitGameButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	void OnMouseDown()
	{
		SendMessageUpwards("QuitGame");
	}
}
