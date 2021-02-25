using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextAction : MonoBehaviour
{
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		GameVariables.CurrentLevel++;
		Application.LoadLevel( GameVariables.LevelsCode[GameVariables.CurrentLevel] );
	}
}
