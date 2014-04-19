using UnityEngine;
using System.Collections;

public class QueryExit : MonoBehaviour {

	public GameObject confirmScreen;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{
		Instantiate(confirmScreen);
	}
}
