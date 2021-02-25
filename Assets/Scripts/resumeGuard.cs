using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class resumeGuard : StateMachineBehaviour
{
    GameObject npc;
    GameObject guardPoint;
    NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;
        if(npc.name == "Ennemy1")
            guardPoint = GameObject.Find("W1");
        else
            guardPoint = GameObject.Find("W2");
        
        agent = npc.GetComponent<NavMeshAgent>();
        agent.SetDestination(guardPoint.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = guardPoint.transform.position - npc.transform.position;
        npc.transform.rotation = Quaternion.Slerp( npc.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   2.0f * Time.deltaTime);
        
        if( Vector3.Distance(guardPoint.transform.position, npc.transform.position) < 0.7f ){
            // Debug.Log(npc.name + " distance to guard " + Vector3.Distance(guardPoint.transform.position, npc.transform.position) );
            agent.isStopped = true;
            agent.ResetPath();
            animator.SetBool("onGuard", true);
        }
    }
}
