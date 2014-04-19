using UnityEngine;
using System.Collections;

public class NavigationArrow : MonoBehaviour {

	public float fadeTime = 1.0f;
	public string levelToLoad = "none";

	public AudioClip clip = null;

	private LevelTransitionManager _lvlTransitoner;

	// Use this for initialization
	void Start () 
	{
		_lvlTransitoner = FindObjectOfType<LevelTransitionManager>();
	}


	void OnMouseDown()
	{
		_lvlTransitoner.ChangeLevel(levelToLoad);

		if(clip != null)
		{
			GameStateManager.GetInstance().PlayClip(clip);
		}
	}
}
