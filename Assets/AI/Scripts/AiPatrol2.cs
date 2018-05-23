using System;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Patrol2")]
public class AiPatrol2 : AiBase
{
	private int i = 0;
	public GameAction GameAction;
	public List<Transform> PatrolPoints { get ; set; }

	private void OnEnable()
	{
		PatrolPoints.Clear();
		GameAction.Call += Call;
	}

	private void Call(object obj)
	{
		PatrolPoints.Add(obj as Transform);
	}


	public override void Navigate(NavMeshAgent ai)
	{	
		if (ai.remainingDistance <= 1)
		{
			ChangePatrolPoint();
		}
		
		ai.destination = PatrolPoints[i].position;
	}

// 	private void ChangePatrolPoint()
// 	{
// 		PatrolPoints = Random.Range(0,PatrolPoints.Count);
// //			i++;
// //		else
// //			i = 0;
// 	}

	private void ChangePatrolPoint()
	{
		if (i < PatrolPoints.Count-1)
			i++;
		else
			i = 0;
	}
}

        // if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        // {
        //     controller.nextWayPoint = Random.Range(0, controller.wayPointList.Count);
        //     Debug.Log("Waypoint reached");
        // }