using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if( collider.name.Contains("Sheep") ){
            collider.gameObject.GetComponent<Animator>().SetTrigger("nearHome");
        }
    }
}
