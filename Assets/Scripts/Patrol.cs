using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    // SourceCode: https://www.youtube.com/watch?v=NEvdyefORBo
    public float awarenessSphereRadius;
    
    GameObject npc;
    GameObject[] waypoints;
    int currentWP;
    NavMeshAgent agent;
    
    void Awake(){
        waypoints = GameObject.FindGameObjectsWithTag("patrol1");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;
        currentWP = 0;

        agent = npc.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentWP].transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( waypoints.Length == 0 ) return;
        if( Vector3.Distance(waypoints[currentWP].transform.position, npc.transform.position) < 3.0f ){
            currentWP++;
            if( currentWP >= waypoints.Length ) currentWP = 0;
            agent.SetDestination(waypoints[currentWP].transform.position);
        }
        var direction = waypoints[currentWP].transform.position - npc.transform.position;
        npc.transform.rotation = Quaternion.Slerp( npc.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   1.0f * Time.deltaTime);
        //npc.transform.Translate(0, 0, Time.deltaTime * 2.0f);

        // CHECKING FOR NEAR SHEEPS
        int sheepsLayerId = 8;
        int layerMask = 1 << sheepsLayerId;

        Collider[] sheeps = Physics.OverlapSphere(npc.transform.position, awarenessSphereRadius, layerMask);
        foreach (Collider sheep in sheeps){
            // Animator sheepAnimator = sheep.gameObject.GetComponent<Animator>(); 
            // sheepAnimator.SetBool("kidnapped", true);
            if(!sheep.GetComponent<Animator>().GetBool("kidnapped")){
                agent.isStopped = true;
                agent.ResetPath();
                animator.SetInteger("StealSheep", 1);
            }
            return; 
        }
    }
}
