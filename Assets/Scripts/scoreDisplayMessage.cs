using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplayMessage : MonoBehaviour
{
    public GameObject gameObject; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score " + GameVariables.Score);
         Text msg = gameObject.GetComponent<Text>();
         if(GameVariables.Score ==  1) 
            msg.text =  "1 sheep out of 12 survived:\n technically, this could have been worse.";
         if(GameVariables.Score ==  2) 
            msg.text =  "2 sheeps out of 12 survived:\n pray they can make children.";
         if(GameVariables.Score ==  3) 
            msg.text =  "3 sheeps out of 12 survived:\n Honestly, your performance was pretty SHEEP.";
         if(GameVariables.Score ==  4) 
            msg.text =  "4 sheeps out of 12 survived:\n Three's a charm, but fourth is still better.";
         if(GameVariables.Score ==  5) 
            msg.text =  "5 sheeps out of 12 survived:\n One could say most abandon the SHEEP... ";
         if(GameVariables.Score ==  6) 
            msg.text =  "6 sheeps out of 12 survived:\n Thanos would approve";
         if(GameVariables.Score ==  7) 
            msg.text =  "7 sheeps out of 12 survived:\n This could definitly have been worse";
         if(GameVariables.Score ==  8) 
            msg.text =  "8 sheeps out of 12 survived:\n Now go eat, looks like there's gonna be mutton for dinner";
         if(GameVariables.Score ==  9) 
            msg.text =  "9 sheeps out of 12 survived:\n Alive and WOOL! Mostly...";
         if(GameVariables.Score == 10) 
            msg.text = "10 sheeps out of 12 survived:\n Keep up! You may earn enough for a LAMBhorgini";
         if(GameVariables.Score == 11) 
            msg.text = "11 sheeps out of 12 survived:\n do you use firefox? cause you are on fire mr Fox";  
         if(GameVariables.Score == 12) 
            msg.text = "12 sheeps out of 12 survived:\n With such amazing leaderSHEEP, you could WOOL the world ";  
    }
}
