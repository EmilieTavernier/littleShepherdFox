using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepDefaultBehavior : MonoBehaviour
{
    private int sheepLayerId = 8;
    private float radius = 6f;

    // Update is called once per frame
    void Update()
    {           
        int layerMask = 1 << sheepLayerId;

        // FINDING NEIGHBOURS
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        Vector3 SteeringForce = new Vector3(0, 0, 0);
        float avgOrientation = 0f;
        Vector3 avgPosition = new Vector3(0, 0, 0);

        int count = 0;
        foreach (Collider collider in colliders){
            // print("collider: " + collider);

            // SEPARATION
            Vector3 ToAgent = transform.position - collider.transform.position;
            SteeringForce += ToAgent;
            //if (ToAgent.magnitude != 0) SteeringForce /= ToAgent.magnitude; 
            // SteeringForce += Vector3.Normalize(ToAgent); //ToAgent.magnitude;

            // ALIGNEMENT
            avgOrientation += collider.transform.rotation.y;
            count++;

            // COHESION
            avgPosition += collider.transform.position;
        }
        // print("SteeringForce : " + SteeringForce);
        //print("Forward : " + transform.transform.forward);
            
        // SEPARATION
        SteeringForce.y = 0;
        SteeringForce = Vector3.Normalize(SteeringForce);
        transform.transform.Translate(SteeringForce * Time.deltaTime, Space.World);

        // ALIGNEMENT
        if(count > 0 ) avgOrientation = avgOrientation/count;
        Vector3 alignementForce = new Vector3(0, 0, 0);
        var speed = 20;
        alignementForce.y = avgOrientation;
        transform.transform.Rotate(alignementForce * speed * Time.deltaTime);

        // COHESION
        if(count > 0 ) avgPosition = avgPosition/count;
        avgPosition.y = 0;
        Vector3 direction = Vector3.Normalize(avgPosition - transform.position);
        transform.transform.Translate(direction * Time.deltaTime, Space.World);

        transform.transform.Translate(transform.transform.forward * Time.deltaTime, Space.World);
    }
}
