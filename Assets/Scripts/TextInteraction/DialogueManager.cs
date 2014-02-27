using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

#region PublicVariables
	public string [] DialogueStrings;

	public float lineLength = 8.5f;

	public float readTime = 0.05f;

	public static string interactionTag = "I";
	public static string playerDialogueTag = "P";
	public static string robotDialogueTag = "R";

	public static string[] delimArray = { ":" };

	public static string sprigDialogueTag = "S:";
	public static string egbertDialogueTag = "E:";
	public static string giovanniDialogueTag = "G:";

#endregion

#region CachedComponents
	private AudioSource _aud;

	private SpriteRenderer _sprRender;

	private TextMesh _textMesh;
#endregion

#region PrivateVariables
	private int index = 0;

	private Color savedSpriteColor, savedTextColor;

    private string _currentAppendingText;

    private float _lineOffset;

	private Dictionary<string, TextBoxCustomizer> _textBoxMap;

	private string _currentTBIdentifier = "I";

#endregion


	// Use this for initialization
	void Start () 
	{
		//Cache our components that we plan on using
		//_aud = GetComponent<AudioSource>();

		_textMesh = GetComponentsInChildren<TextMesh>()[0];

		_sprRender = GetComponent<SpriteRenderer>();

		//Grab all text boxes we have as children
		TextBoxCustomizer[] textBoxes = GetComponentsInChildren<TextBoxCustomizer>();

		//Store them in an easily accessible dictionary
		_textBoxMap = new Dictionary<string, TextBoxCustomizer>();

		foreach(TextBoxCustomizer textB in textBoxes)
		{
			if(textB.type == TextBoxCustomizer.TextBoxType.DEFAULT)
			{
				_textBoxMap.Add(interactionTag, textB);
			}
			else if(textB.type == TextBoxCustomizer.TextBoxType.PLAYER)
			{
				_textBoxMap.Add(playerDialogueTag, textB);
			}
			else if(textB.type == TextBoxCustomizer.TextBoxType.ROBOT)
			{
				_textBoxMap.Add(robotDialogueTag, textB);
				//_textBoxMap.Add(sprigDialogueTag, textB);
				//_textBoxMap.Add(egbertDialogueTag, textB);
				//_textBoxMap.Add(giovanniDialogueTag, textB);
			}
		}

		HideMe();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		//_aud.Play();

		if(index < DialogueStrings.Length)
		{
			string text = DialogueStrings[index];
			//Check for blank strings and return early
			if(text.Length == 0)
			{
				HideMe();
				return;
			}
			else
			{
				SetTextBoxText(text);
				++index;
			}
		}
		else
		{
			HideMe();
		}

	}
    
    private void StartAppendingText()
    {
        if (_currentAppendingText.Length == 0)
            return;

        //Get the top character of the string
        _textMesh.text += _currentAppendingText.Substring(0, 1);

        //pop the first character off
        _currentAppendingText = _currentAppendingText.Remove(0, 1);

        Invoke("StartAppendingText", readTime);
    }

	private void SetTextBoxText(string text)
	{
        //clear out the offset number
        _lineOffset = 0.0f;

        //unescape the string to allow newlines
        _currentAppendingText = System.Text.RegularExpressions.Regex.Unescape(text);

		//Text size needs a text mesh
		_textMesh.text = _currentAppendingText;

		TextSize ts = new TextSize(_textMesh);
		ts.FitToWidth(lineLength);

		//Retrieve the modified string
		_currentAppendingText = _textMesh.text;

		//Split the tag and the text from the whole text line
		string[] splitLines = _currentAppendingText.Split(delimArray, System.StringSplitOptions.RemoveEmptyEntries);

		//Catch if we split correctly
		if(splitLines.Length == 2)
		{
			_currentTBIdentifier = splitLines[0];
			_currentAppendingText = splitLines[1];

			HideAllTextBoxes();

			ShowSpecifiedText(_currentTBIdentifier);
		}

		//Clear the textmesh since we're going to be appending to it
		_textMesh.text = "";

        StartAppendingText();
	}

	private void SetTextBoxTextByIndex( int ind )
	{
		index = ind;

		string text = DialogueStrings[index];
		++index;

		SetTextBoxText(text);
	}

	public void InitializeAndShowText( string[] dialogueStrings, bool characterDialogue = false )
	{
		if(dialogueStrings.Length == 0)
		{
			Debug.LogError("Attempted to set text box strings to empty set", gameObject);
			return;
		}

		//A bit of work for the garbage collector, possibly refactor later
		DialogueStrings = dialogueStrings;

		SetTextBoxTextByIndex(0);

		if(characterDialogue == true)
		{
			//_sprRender.sprite = robotSpeakingSprite;
			//playerLastSpoke = false;
		}
		else
		{
			//_sprRender.sprite = defaultInteractionSprite;
		}

		ShowMe();
	}

	public void HideMe()
	{
		HideAll();
		//essential to allow clicking behind object when hidden
		collider2D.enabled = false;
	}

	public void ShowMe()
	{
		ShowSpecifiedText(_currentTBIdentifier);

		collider2D.enabled = true;
	}

	private void ShowSpecifiedText( string textBoxTag )
	{
		_textBoxMap[textBoxTag].gameObject.SetActive(true);

		savedTextColor = _textMesh.color;
		savedTextColor.a = 255;
		_textMesh.color = savedTextColor;
	}

	private void HideAll()
	{
		HideAllTextBoxes();

		savedTextColor = _textMesh.color;
		savedTextColor.a = 0;
		_textMesh.color = savedTextColor;
	}

	private void HideAllTextBoxes()
	{
		foreach(var textB in _textBoxMap.Values)
		{
			textB.gameObject.SetActive(false);
		}
	}
}
