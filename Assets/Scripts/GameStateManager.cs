using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour 
{
	public enum Age { CHILD, ADULT, ELDERLY };

	public Age currentAge = Age.CHILD;

	private static GameStateManager _instance;

	private SimpleMusicPlayer _musicPlayer;

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

		_musicPlayer = GetComponent<SimpleMusicPlayer>();
	}

	public static GameStateManager GetInstance()
	{
		return _instance;
	}

	public void AdvanceAge()
	{
		if(currentAge == Age.CHILD)
		{
			currentAge = Age.ADULT;
			PlaySound(SimpleMusicPlayer.ADULT_TRACK_NAME);
		}
		else if(currentAge == Age.ADULT)
		{
			currentAge = Age.ELDERLY;
			PlaySound(SimpleMusicPlayer.ELDER_TRACK_NAME);
		}
		else if(currentAge == Age.ELDERLY)
		{
			currentAge = Age.CHILD;
			PlaySound(SimpleMusicPlayer.CHILD_TRACK_NAME);
		}
	}

	public Age GetAge()
	{
		return currentAge;
	}

	private void PlaySound( string name )
	{
		_musicPlayer.PlaySoundByName(name, true);
	}

}
