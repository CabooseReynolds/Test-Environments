using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By Anthony Romrell
public class RotationSpeed : MonoBehaviour
{

	public float Rotationspeedtoobj;
	
	public GameAction SendAction;

	private void Start()
	{
		SendAction.Call(Rotationspeedtoobj);
	}

}
