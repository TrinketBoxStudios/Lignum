using UnityEngine;
using System.Collections;

public class MusicBoxTransitionAnimation : MonoBehaviour {

	private Animator _animator;

	public string toAnimate;

	public float delayToAnimate = 0.8f;
	public float animationLength = 1.5f;
	
	public Sprite reverseFrame;

	private string levelToLoad;

	// Use this for initialization
	void Start () 
	{
		_animator = GetComponent<Animator>();

		switch(GameStateManager.GetInstance().GetAge())
		{
			case GameStateManager.Age.CHILD:
			{
				levelToLoad = "1_MainMenu";
				toAnimate = "TrinketBox";
				break;
			}
				
			case GameStateManager.Age.ADULT:
			{
				levelToLoad = "1_MainMenu";
				toAnimate = "TrinketBox";
				break;
			}
				
			case GameStateManager.Age.ELDERLY:
			{
				levelToLoad = "13_Credits";
				toAnimate = "ReverseAnimation";
				SpriteRenderer sprRender = GetComponent<SpriteRenderer>();
				sprRender.sprite = reverseFrame;

				delayToAnimate = 0.0f;
				break;
			}
		}

		Invoke("Animate", delayToAnimate);
	}

	void Animate()
	{
		_animator.Play(toAnimate); 

		Invoke("TransitionLevel", animationLength);
	}

	void TransitionLevel()
	{
		FindObjectOfType<LevelTransitionManager>().ChangeLevel(levelToLoad);
	}
}
