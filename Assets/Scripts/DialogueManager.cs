using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {

	public string [] DialogueStrings;

	public float lineLength = 8.5f;

	private int index = 0;

	private AudioSource _aud;

	private SpriteRenderer _sprRender;

	private TextMesh _textMesh;

	private Color savedSpriteColor, savedTextColor;

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

	private void SetTextBoxText(string text)
	{
		_textMesh.text = System.Text.RegularExpressions.Regex.Unescape(text);
		TextSize ts = new TextSize(_textMesh);
		ts.FitToWidth(lineLength);
	}

	private void SetTextBoxTextByIndex( int ind )
	{
		index = ind;

		string text = DialogueStrings[index];
		++index;

		SetTextBoxText(text);
	}

	public void InitializeAndShowText( string[] dialogueStrings )
	{
		//A bit of work for the garbage collector, possibly refactor later
		DialogueStrings = dialogueStrings;

		SetTextBoxTextByIndex(0);

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
