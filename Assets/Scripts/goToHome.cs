using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class goToHome : StateMachineBehaviour
{
    GameObject sheep;
    GameObject house;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        house = GameObject.Find("PlayerHouse");
        sheep = animator.gameObject;

        NavMeshAgent agent = sheep.GetComponent<NavMeshAgent>();
        agent.SetDestination(house.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = house.transform.position - sheep.transform.position;
        sheep.transform.rotation = Quaternion.Slerp(sheep.transform.rotation,
                                              Quaternion.LookRotation(direction),
                                              1.0f * Time.deltaTime);
    }
}
