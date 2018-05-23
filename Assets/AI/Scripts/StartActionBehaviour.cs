using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By Anthony Romrell
//This goes on the AI and the Player. 
//For the AI, you can set it for the patrol points or selected actions
//For Player, you want to set use the set player transform script.
public class StartActionBehaviour : MonoBehaviour
{
	public GameAction GameAction;

	private void Start()
	{
		GameAction.Call(transform);
	}
}