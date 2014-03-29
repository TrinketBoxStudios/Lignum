using UnityEngine;
using System.Collections;

public class MusicBoxDelayAnim : MonoBehaviour {

	protected Animator animator;
	protected SpriteRenderer sprRender;

	private int alphaID = 0;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		sprRender = GetComponent<SpriteRenderer>();

		alphaID = Animator.StringToHash("Alpha");
	}
	
	// Update is called once per frame
	void Update () 
	{
		animator.SetFloat(alphaID, sprRender.color.a);
	}
}
