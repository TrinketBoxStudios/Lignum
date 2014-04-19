using UnityEngine;
using System.Collections;

public class SimpleClickSound : MonoBehaviour {

	public AudioClip clip;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{
		GameStateManager.GetInstance().PlayClip(clip);
	}
}
