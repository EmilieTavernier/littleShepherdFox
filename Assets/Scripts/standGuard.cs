using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standGuard : StateMachineBehaviour
{

    public float awarenessSphereRadius;
    GameObject npc;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         npc = animator.gameObject;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // CHECKING FOR NEAR SHEEPS
        int sheepsLayerId = 8;
        int layerMask = 1 << sheepsLayerId;

        Collider[] sheeps = Physics.OverlapSphere(npc.transform.position, awarenessSphereRadius, layerMask);
        foreach (Collider sheep in sheeps){
            // Animator sheepAnimator = sheep.gameObject.GetComponent<Animator>(); 
            // sheepAnimator.SetBool("kidnapped", true);
            //if(!sheep.GetComponent<Animator>().GetBool("kidnapped")){
                animator.SetInteger("StealSheep", 1);
            //}
            return; 
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("onGuard", false);
    }

}
