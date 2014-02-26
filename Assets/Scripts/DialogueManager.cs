using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {

	public string [] DialogueStrings;

	public float lineLength = 8.5f;

	public Sprite defaultInteractionSprite;
	public Sprite playerSpeakingSprite;
	public Sprite robotSpeakingSprite;

	private bool playerLastSpoke = false;

	private int index = 0;

	private AudioSource _aud;

	private SpriteRenderer _sprRender;

	private TextMesh _textMesh;

	private Color savedSpriteColor, savedTextColor;

    private string _currentAppendingText;

    private float _lineOffset;

	// Use this for initialization
	void Start () 
	{
		//_aud = GetComponent<AudioSource>();

		_textMesh = GetComponentsInChildren<TextMesh>()[0];

		_sprRender = GetComponent<SpriteRenderer>();

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
			SetTextBoxText(DialogueStrings[index]);
			++index;
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

        //Wrap the text around the line length
        TextSize ts = new TextSize(_textMesh);

        if (ts.GetTextWidth(_textMesh.text) - _lineOffset >= lineLength)
        {
            _lineOffset += lineLength;

            ts.FitToWidth(lineLength);
        }

        Invoke("StartAppendingText", 0.05f);
    }

	private void SetTextBoxText(string text)
	{
        //Clear the textmesh since we're going to be appending to it
        _textMesh.text = "";

        //clear out the offset number
        _lineOffset = 0.0f;

        //unescape the string to allow newlines
        _currentAppendingText = System.Text.RegularExpressions.Regex.Unescape(text);

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

		if(characterDialogue == true && playerLastSpoke == true)
		{
			_sprRender.sprite = robotSpeakingSprite;
			playerLastSpoke = false;
		}
		else if(characterDialogue == true && playerLastSpoke == false)
		{
			_sprRender.sprite = playerSpeakingSprite;
			playerLastSpoke = true;
		}
		else
		{
			_sprRender.sprite = defaultInteractionSprite;
		}

		ShowMe();
	}

	public void HideMe()
	{
		SetTransparencyAll(0);
		//essential to allow clicking behind object when hidden
		collider2D.enabled = false;
	}

	public void ShowMe()
	{
		SetTransparencyAll(255);

		collider2D.enabled = true;
	}

	private void SetTransparencyAll( int alpha )
	{
		savedSpriteColor = _sprRender.color;
		savedSpriteColor.a = alpha;
		_sprRender.color = savedSpriteColor;
		
		savedTextColor = _textMesh.color;
		savedTextColor.a = alpha;
		_textMesh.color = savedTextColor;
	}
}
