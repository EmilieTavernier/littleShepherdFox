using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepAgentDefaultBehavior : StateMachineBehaviour
{
    private int sheepLayerId = 8;
    private float radius = 6f;
    GameObject sheepNpc;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sheepNpc = animator.gameObject;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int layerMask = 1 << sheepLayerId;

        // FINDING NEIGHBOURS
        Collider[] colliders = Physics.OverlapSphere(sheepNpc.transform.position, radius, layerMask);
        Vector3 SteeringForce = new Vector3(0, 0, 0);
        float avgOrientation = 0f;
        Vector3 avgPosition = new Vector3(0, 0, 0);

        int count = 0;
        foreach (Collider collider in colliders){
            if(collider != null){
                // print("collider: " + collider);

                // SEPARATION
                Vector3 ToAgent = sheepNpc.transform.position - collider.transform.position;
                SteeringForce += ToAgent;
                //if (ToAgent.magnitude != 0) SteeringForce /= ToAgent.magnitude; 
                // SteeringForce += Vector3.Normalize(ToAgent); //ToAgent.magnitude;

                // ALIGNEMENT
                avgOrientation += collider.transform.rotation.y;
                count++;

                // COHESION
                avgPosition += collider.transform.position;
            }
        }
        // print("SteeringForce : " + SteeringForce);
        //print("Forward : " + sheepNpc.transform.forward);
            
        // SEPARATION
        SteeringForce.y = 0;
        SteeringForce = Vector3.Normalize(SteeringForce);
        sheepNpc.transform.Translate(SteeringForce * Time.deltaTime, Space.World);

        // ALIGNEMENT
        if(count > 0 ) avgOrientation = avgOrientation/count;
        Vector3 alignementForce = new Vector3(0, 0, 0);
        var speed = 20;
        alignementForce.y = avgOrientation;
        sheepNpc.transform.Rotate(alignementForce * speed * Time.deltaTime);

        // COHESION
        if(count > 0 ) avgPosition = avgPosition/count;
        avgPosition.y = 0;
        Vector3 direction = Vector3.Normalize(avgPosition - sheepNpc.transform.position);
        sheepNpc.transform.Translate(direction * Time.deltaTime, Space.World);

        sheepNpc.transform.Translate(sheepNpc.transform.forward * Time.deltaTime, Space.World);  
    }

}
