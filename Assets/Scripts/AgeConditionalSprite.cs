using UnityEngine;
using System.Collections;

public class AgeConditionalSprite : MonoBehaviour {

	public Sprite childSprite;
	public Sprite adultSprite;
	public Sprite elderlySprite;

	// Use this for initialization
	void Start () 
	{
		SpriteRenderer spRender = GetComponent<SpriteRenderer>();

		switch(GameStateManager.GetInstance().GetAge())
		{
			case GameStateManager.Age.CHILD:
			{
				spRender.sprite = childSprite;
				break;
			}
				
			case GameStateManager.Age.ADULT:
			{
				spRender.sprite = adultSprite;
				break;
			}
				
			case GameStateManager.Age.ELDERLY:
			{
				spRender.sprite = elderlySprite;
				break;
			}
		}

	}

	void Awake()
	{

	}
}
