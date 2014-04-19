using UnityEngine;
using System.Collections;

public class ExitOnClick : MonoBehaviour 
{

	void OnMouseDown()
	{
		Application.Quit();
	}
}
