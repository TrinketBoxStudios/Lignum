using UnityEngine;
using System.Collections;

public class EndgameScript : MonoBehaviour 
{
	public string MainMenuLevel = "1_MainMenu";
	public string CreditsLevel = "13_Credits";

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{
		LevelTransitionManager lvlMan = FindObjectOfType<LevelTransitionManager>();

		GameStateManager.GetInstance().AdvanceAge();

		if(GameStateManager.GetInstance().GetAge() == GameStateManager.Age.CHILD)
		{
			lvlMan.ChangeLevel(CreditsLevel);
		}
		else
		{
			lvlMan.ChangeLevel(MainMenuLevel);
		}
	}
}
