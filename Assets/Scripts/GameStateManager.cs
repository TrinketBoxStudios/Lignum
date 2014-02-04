using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour 
{
	public enum Age { CHILD, ADULT, ELDERLY };

	public Age currentAge = Age.CHILD;

	private static GameStateManager _instance;

	// Use this for initialization
	void Start () 
	{
		//Peculiarity with unity scenes that will try and reload the object every time
		//everytime the scene is loaded, so destroy the imposters
		if(FindObjectsOfType<GameStateManager>().Length > 1)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			DontDestroyOnLoad(gameObject);

			_instance = this;
		}
	}

	public static GameStateManager GetInstance()
	{
		return _instance;
	}

}
