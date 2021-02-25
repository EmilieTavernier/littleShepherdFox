using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingKidnapper : StateMachineBehaviour
{
    public float contactDistance;

    GameObject sheep;
    GameObject targetedNPC;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sheep = animator.gameObject;

        int foxLayerId = 9;
        int layerMask = 1 << foxLayerId;

        Collider[] NPCs = Physics.OverlapSphere(sheep.transform.position, contactDistance, layerMask);
        foreach (Collider npc in NPCs){
            targetedNPC = npc.gameObject;
            return;
        }   
        // No sheep found = abort kidnapping mission
        animator.SetBool("kidnapped", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( targetedNPC != null ){
            var direction = targetedNPC.transform.position - sheep.transform.position;
            sheep.transform.rotation = Quaternion.Slerp( sheep.transform.rotation,
                                                         Quaternion.LookRotation(direction),
                                                         1.0f * Time.deltaTime);
            sheep.transform.Translate(0, 0, Time.deltaTime * 2.0f);
        }
        else animator.SetBool("kidnapped", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
