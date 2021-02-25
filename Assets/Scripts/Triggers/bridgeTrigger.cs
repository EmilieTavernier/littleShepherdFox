using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bridgeTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if( collider.name.Contains("bridgePart") ){
            collider.gameObject.GetComponent<Animator>().SetBool("isOnBridgeLocation", true);
            collider.gameObject.GetComponent<Animator>().SetBool("isPicked", false);
            Level2Variables.BridgePartAssembled++;
            if(Level2Variables.BridgePartAssembled == 3){
                GameObject bridge = GameObject.Find("bridgeFull"); 
                bridge.GetComponent<Collider>().enabled = true;
                bridge.GetComponent<Renderer>().enabled = true;

                Transform bridgeParts = GameObject.Find("bridgeParts").transform;
                for (int i = 0; i < bridgeParts.childCount; i++){            
                    bridgeParts.GetChild(i).GetComponent<Collider>().enabled = false;
                    bridgeParts.GetChild(i).GetComponent<Renderer>().enabled = false;
                }

                Transform sheepsPack = GameObject.Find("sheepPack").transform;
                foreach (Transform sheep in sheepsPack)
                {
                    sheep.gameObject.GetComponent<NavMeshAgent>().enabled = true;
                    sheep.gameObject.GetComponent<Animator>().SetTrigger("nearHome");
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if( collider.name.Contains("bridgePart") ){
            collider.gameObject.GetComponent<Animator>().SetBool("isOnBridgeLocation", false);
        }
    }
}
