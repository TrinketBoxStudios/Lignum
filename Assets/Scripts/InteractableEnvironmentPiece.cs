using UnityEngine;
using System.Collections;

public class InteractableEnvironmentPiece : MonoBehaviour 
{
	public string[] interactionDialogue;
	
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
		_dlgBox.InitializeAndShowText(interactionDialogue);
	}
}
