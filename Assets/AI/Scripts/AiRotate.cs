using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Rotate")]
public class AiRotate : AiBase
{
    public GameAction GameAction;
    // The destination marker.
    public GameAction RotationspeedtoObj;
    private Transform Destination;
    private float Rotationspeeds;
    // Angular speed in radians per sec.
private void OnEnable()
	{
		GameAction.Call += Call;
    //    RotationspeedtoObj.Call += Rotationspeed;
	}

private void Call(object obj)
	{
		Destination = obj as Transform;
	}

// private void Rotationspeed(object obj)
// 	{
// 		Rotationspeeds = obj as float;
// 	}

public override void Navigate(NavMeshAgent ai)
    {
        Vector3 DestinationDir = Destination.position - ai.transform.position;
        // The step size is equal to speed times frame time.
        float step = Rotationspeeds * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(ai.transform.forward, DestinationDir, step, 0.0f);
        Debug.DrawRay(ai.transform.position, newDir, Color.red);
        // Move our position a step closer to the Destination.
        ai.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
//     void Update()
//     {
//         Vector3 DestinationDir = Destination.position - transform.position;
//         // The step size is equal to speed times frame time.
//         float step = speed * Time.deltaTime;
//         Vector3 newDir = Vector3.RotateTowards(transform.forward, DestinationDir, step, 0.0f);
//         Debug.DrawRay(transform.position, newDir, Color.red);
//         // Move our position a step closer to the Destination.
//         transform.rotation = Quaternion.LookRotation(newDir);
//     }
// }