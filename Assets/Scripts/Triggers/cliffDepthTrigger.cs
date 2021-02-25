using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cliffDepthTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if( collider.name.Contains("Sheep") ){
            collider.gameObject.GetComponent<Animator>().SetTrigger("destroy");
        }
        else if( collider.name == "Player" ){
            GameVariables.LoseCode = 1;
            Application.LoadLevel(3); // Load Gameover screen
        }
    }
}
