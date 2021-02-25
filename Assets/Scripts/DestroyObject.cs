using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        string name = animator.gameObject.name;
        Destroy(animator.gameObject);
        animator.gameObject.transform.parent = null;

        if( name.Contains("Sheep") ){
            GameObject sheepPack = GameObject.Find("sheepPack");
            if( sheepPack.transform.childCount == 0 ){
                GameObject playerHouse = GameObject.Find("PlayerHouse");
                if( GameVariables.Score > 0 ){
                    Application.LoadLevel(4);
                }
                else {
                    GameVariables.LoseCode = 0;
                    Application.LoadLevel(3);
                }
                return;
            }
        }
    }
}
