using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class LevelTransitionManager : MonoBehaviour 
{
	public float transitionSpeed = 1.0f;
	// Use this for initialization
	void Start () 
	{	
		SpriteRenderer sprRender = GetComponent<SpriteRenderer>();

		//Juggle the alpha property to set the current alpha to full, then target alpha to 0
		Color tempColor = sprRender.color;
		tempColor.a = 1.0f;
		sprRender.color = tempColor;
		tempColor.a = 0.0f;

		HOTween.To(sprRender, transitionSpeed, new TweenParms().Prop("color", tempColor));
	}

	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ChangeLevel( string level )
	{
		//Pass the level to load to the callback by using generic objects
		object[] objParam = new object[1];
		objParam[0] = level;

		SpriteRenderer sprRender = GetComponent<SpriteRenderer>();
		
		Color tempColor = sprRender.color;
		tempColor.a = 1.0f;
		HOTween.To(sprRender, transitionSpeed, new TweenParms().Prop("color", tempColor).OnComplete(LoadLevel, objParam));
	}

	void LoadLevel(TweenEvent tEvent)
	{
		string level = tEvent.parms[0] as string;

		Application.LoadLevel(level);
	}


}
