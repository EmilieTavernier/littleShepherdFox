using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picked : StateMachineBehaviour
{
    public Vector3 offset;
    public float distance;

    private GameObject target;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.Find("Player");
        animator.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.position = target.transform.position + offset; 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( !animator.GetBool("isOnBridgeLocation") ){
            // We drop the object with the same y rotation as the player 
            animator.gameObject.transform.eulerAngles = new Vector3(0, target.transform.eulerAngles.y, 0);

            // We drop the object in front of us at a small distance
            var currentRotation = Quaternion.Euler(0, animator.gameObject.transform.eulerAngles.y, 0);
            animator.gameObject.transform.position = target.transform.position;       
            animator.gameObject.transform.position += currentRotation * Vector3.forward * distance;
            animator.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else { // ONLY FOR BRIDGE PARTS
            Destroy(animator.gameObject.GetComponent<Rigidbody>());
            Transform bridgePart = animator.gameObject.transform;

            // We drop the object perpendicular to the ravine
            bridgePart.eulerAngles = new Vector3(0, 90, 0);

            // We use the child index to increment x position (to place all siblings side by side)
            int i = bridgePart.GetSiblingIndex();
            bridgePart.position = new Vector3(15.0f + i*2, 0.4f, 11.5f);     
            
            // We enlarge the bridge part to cross the ravine
            bridgePart.localScale = new Vector3(13.0f, 0.22f, 1.5f);
        }
    }
}
