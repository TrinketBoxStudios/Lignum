﻿using UnityEngine;
using System.Collections;

public class CharacterDialogueInteraction : MonoBehaviour 
{
	public string[] childInteractionDialogue;
	public string[] adultInteractionDialogue;
	public string[] elderlyInteractionDialogue;
	
	private DialogueManager _dlgBox;

	// Use this for initialization
	void Start () 
	{
		_dlgBox = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		switch(GameStateManager.GetInstance().GetAge())
		{
			case GameStateManager.Age.CHILD:
			{
				_dlgBox.InitializeAndShowText(childInteractionDialogue, true);
				break;
			}

			case GameStateManager.Age.ADULT:
			{
				_dlgBox.InitializeAndShowText(adultInteractionDialogue, true);
				break;
			}

			case GameStateManager.Age.ELDERLY:
			{
				_dlgBox.InitializeAndShowText(elderlyInteractionDialogue, true);
				break;
			}
		}
	}
}
