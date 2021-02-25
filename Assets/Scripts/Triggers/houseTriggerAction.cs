using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseTriggerAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameVariables.Score = 0;
        Level2Variables.BridgePartAssembled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        string name = collider.name; 

        if( name.Contains("Sheep") ){
            Debug.Log("House score " + GameVariables.Score);
            Animator sheepAnimator = collider.gameObject.GetComponent<Animator>();
            
            if( !sheepAnimator.GetBool("destroy") ){
                GameVariables.Score = GameVariables.Score + 1;
                sheepAnimator.SetBool("destroy", true);
            }
        }
    }
}
