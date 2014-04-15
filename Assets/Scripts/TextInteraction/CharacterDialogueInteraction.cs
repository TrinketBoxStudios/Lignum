using UnityEngine;
using System.Collections;

public class CharacterDialogueInteraction : MonoBehaviour 
{
	public string scriptCharacterPrefix; 
	private string[] childInteractionDialogue;
	private string[] adultInteractionDialogue;
	private string[] elderlyInteractionDialogue;
	
	private DialogueManager _dlgBox;

	// Use this for initialization
	void Start () 
	{
		_dlgBox = FindObjectOfType<DialogueManager>();

		childInteractionDialogue = LoadInteractionScript(scriptCharacterPrefix + "ChildScript");
		adultInteractionDialogue =  LoadInteractionScript(scriptCharacterPrefix + "AdultScript");
		elderlyInteractionDialogue =  LoadInteractionScript(scriptCharacterPrefix + "ElderlyScript");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	string[] LoadInteractionScript( string fileName )
	{
		TextAsset scriptFile = (TextAsset)Resources.Load (fileName, typeof(TextAsset));

		if (scriptFile != null) 
		{
			return scriptFile.text.Split (new string[] { "\n", "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
		} 
		else 
		{
			Debug.LogError(fileName + " could not be opened");
		}

		return null;
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
