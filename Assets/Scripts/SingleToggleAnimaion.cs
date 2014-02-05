using UnityEngine;
using System.Collections;

public class SingleToggleAnimaion : MonoBehaviour 
{
	public string[] childInteractionDialogue;
	public string[] adultInteractionDialogue;
	public string[] elderlyInteractionDialogue;

	//Starting sprite frame (Assumed)
	public Sprite frameOne;
	//Frame to toggle to
	public Sprite frameTwo;

	private int _currentFrame = 0;

	private DialogueManager _dlgBox;

	private SpriteRenderer _sprRender;
	// Use this for initialization
	void Start () 
	{
		_sprRender = GetComponent<SpriteRenderer>();

		_dlgBox = FindObjectOfType<DialogueManager>();
	}

	void OnMouseDown()
	{
		ToggleAnimation();
	}

	void ToggleAnimation()
	{
		if(_currentFrame == 0)
		{
			_sprRender.sprite = frameTwo;
			_currentFrame = 1;

			//Only send this is we're 'opening' the object, 
			//as most objects go from closed to open on the first frame
			SendTextToDialogueBox();
		}
		else if(_currentFrame == 1)
		{
			_sprRender.sprite = frameOne;
			_currentFrame = 0;

			_dlgBox.HideMe();
		}
	}

	void SendTextToDialogueBox()
	{
		switch(GameStateManager.GetInstance().GetAge())
		{
		case GameStateManager.Age.CHILD:
		{
			_dlgBox.InitializeAndShowText(childInteractionDialogue);
			break;
		}
			
		case GameStateManager.Age.ADULT:
		{
			_dlgBox.InitializeAndShowText(adultInteractionDialogue);
			break;
		}
			
		case GameStateManager.Age.ELDERLY:
		{
			_dlgBox.InitializeAndShowText(elderlyInteractionDialogue);
			break;
		}
		}
	}
}
