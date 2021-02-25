using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrpSteeringBehavior : MonoBehaviour
{
    private int sheepLayerId = 8;
    private float radius = 4f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int children = transform.childCount;
        for (int i=0; i<children; i++){
            Transform child = transform.GetChild(i);              
            //print("Sheep is: " + child);
            
            int layerMask = 1 << sheepLayerId;

            // FINDING NEIGHBOURS
            Collider[] colliders = Physics.OverlapSphere(child.position, radius, layerMask);
            Vector3 SteeringForce = new Vector3(0, 0, 0);
            float avgOrientation = 0f;
            Vector3 avgPosition = new Vector3(0, 0, 0);

            int count = 0;
            foreach (Collider collider in colliders){
                // print("collider: " + collider);

                // SEPARATION
                Vector3 ToAgent = child.position - collider.transform.position;
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
            //print("Forward : " + child.transform.forward);
            
            // SEPARATION
            SteeringForce.y = 0;
            SteeringForce = Vector3.Normalize(SteeringForce);
            child.transform.Translate(SteeringForce * Time.deltaTime, Space.World);

            // ALIGNEMENT
            if(count > 0 ) avgOrientation = avgOrientation/count;
            Vector3 alignementForce = new Vector3(0, 0, 0);
            var speed = 20;
            alignementForce.y = avgOrientation;
            child.transform.Rotate(alignementForce * speed * Time.deltaTime);

            // COHESION
            if(count > 0 ) avgPosition = avgPosition/count;
            avgPosition.y = 0;
            Vector3 direction = Vector3.Normalize(avgPosition - child.position);
            child.transform.Translate(direction * Time.deltaTime, Space.World);

            child.transform.Translate(child.transform.forward * Time.deltaTime, Space.World);

        }
    }
}
