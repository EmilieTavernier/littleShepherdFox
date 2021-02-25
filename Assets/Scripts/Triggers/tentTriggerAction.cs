using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentTriggerAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        string name = collider.name; 

        if( name.Contains("Sheep") ){
            // Debug.Log(collider.name);
            Animator sheepAnimator = collider.gameObject.GetComponent<Animator>();
            if( sheepAnimator.GetBool("kidnapped") )
                sheepAnimator.SetTrigger("destroy");
        }
        if( name.Contains("Ennemy") ){
            // Debug.Log(collider.name);
            Animator ennemyAnimator = collider.gameObject.GetComponent<Animator>();
            ennemyAnimator.SetInteger("StealSheep", 0);
        }
    }
}
