using UnityEngine;
using System.Collections;

public class PauseScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void ResumeGame()
	{
		Destroy(gameObject);
	}

	void QuitGame()
	{
		Application.LoadLevel("MainMenu");
	}
}
