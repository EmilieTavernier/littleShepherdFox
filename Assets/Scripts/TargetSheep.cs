using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSheep : StateMachineBehaviour
{
    public float awarenessSphereRadius;
    public float contactDistance;

    GameObject npc;
    GameObject targetedSheep;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;

        int sheepsLayerId = 8;
        int layerMask = 1 << sheepsLayerId;

        Collider[] sheeps = Physics.OverlapSphere(npc.transform.position, awarenessSphereRadius, layerMask);
        foreach (Collider sheep in sheeps){
            targetedSheep = sheep.gameObject;
            if(!targetedSheep.GetComponent<Animator>().GetBool("kidnapped")) return;
        }   
        // No sheep found = abort kidnapping mission
        animator.SetInteger("StealSheep", 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( targetedSheep == null ){
            animator.SetInteger("StealSheep", 0);
        }
        else{
            var direction = targetedSheep.transform.position - npc.transform.position;
            npc.transform.rotation = Quaternion.Slerp( npc.transform.rotation,
                                                       Quaternion.LookRotation(direction),
                                                       1.0f * Time.deltaTime);
            npc.transform.Translate(0, 0, Time.deltaTime * 2.0f);

            float distanceToSheep = Vector3.Distance(targetedSheep.transform.position, npc.transform.position);
            if( distanceToSheep < contactDistance ){
                Animator sheepAnimator = targetedSheep.gameObject.GetComponent<Animator>();
                if(!sheepAnimator.GetBool("kidnapped")){
                    sheepAnimator.SetBool("kidnapped", true);
                    animator.SetInteger("StealSheep", 2);
                }
                else {
                    animator.SetInteger("StealSheep", 0);
                }
            }
        }
    }
}
