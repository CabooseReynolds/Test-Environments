using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Made By Anthony Romrell
public class AiBehaviour : MonoBehaviour
{

	public NavMeshAgent Agent;
	public Animator Anims;
	public AiBrain Brain;
	public AiBase StartAiBase;


	void Start ()
	{
		Agent = GetComponent<NavMeshAgent>();
		// AiBrain tempBrain = ScriptableObject.CreateInstance<AiBrain>();
		// tempBrain.AiBase = Brain.AiBase;
		// Brain = tempBrain;
	}

	void Update () {
		Brain.AiBase.Navigate(Agent);
	}

	private void OnTriggerEnter(Collider other)
	{
		Anims.SetTrigger("Hunt");
	}

	private void OnTriggerExit(Collider other)
	{
		StartCoroutine(Search());
	}

	IEnumerator Search()
            {
                Anims.SetTrigger("Search");
				Debug.Log ("Searching");
                	{
                	yield return new WaitForSeconds(3);
					Anims.ResetTrigger("Search");
					Debug.Log ("Cancel Searching beginning Patrol");
                	Anims.SetTrigger("Patrol");
					StopAllCoroutines();
                    }
            }
	
	private void OnEnable()
	{
		Brain.AiBase = StartAiBase;
	}
}
