using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kidnapSheep : StateMachineBehaviour
{
    GameObject npc;
    GameObject tent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;
        if( npc.name == "Ennemy1" )
            tent = GameObject.Find("Tent1");
        else
            tent = GameObject.Find("Tent2");

        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
        agent.SetDestination(tent.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = tent.transform.position - npc.transform.position;
        npc.transform.rotation = Quaternion.Slerp( npc.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   1.0f * Time.deltaTime);
    }
}
