using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loseDisplay : MonoBehaviour
{
    public GameObject gameObject; 

    // Start is called before the first frame update
    void Start()
    {
         Text msg = gameObject.GetComponent<Text>();
         if(GameVariables.LoseCode ==  0) 
            msg.text =  "You lost all your sheeps";
         if(GameVariables.LoseCode ==  1) 
            msg.text =  "You died.";
    }
}
