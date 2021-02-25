using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class retryButton : MonoBehaviour
{
	public Button retryBtn;

	void Start () {
		retryBtn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Application.LoadLevel( GameVariables.LevelsCode[GameVariables.CurrentLevel] );
	}
}
