using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public GameObject scores;
	public GameObject powerups;
	public GameObject uiButton;
	public GameObject speed;
	public GameObject lifePanel;

	public Text tutorialText;

	public string mainMenu;

	private int state;

	// Use this for initialization
	void Start () {
		state = 0;
		//state 0 -> player
		//state 1 -> speed
		//state 2 -> scores
		//state 3 -> UIbuttons
		//state 4 -> Lives
		//state 5 -> powerups
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("NextStep"))
		{
			//deactivate current UI, change state and activate the new one
			activation(state, false);
			state++;
			activation(state, true);
		}
		if (CrossPlatformInputManager.GetButtonDown("BackStep") && state > 0)
		{
			activation(state, false);
			state--;
			activation(state, true);
		}
	}

	void activation(int state, bool active)
	{
		switch(state)
		{
		case(1):
			speed.SetActive(active);
			break;
		case(2):
			scores.SetActive(active);
			break;
		case(3):
			uiButton.SetActive(active);
			break;
		case(4):
			lifePanel.SetActive(active);
			break;
		case(5):
			powerups.SetActive(active);
			break;
		case(6):
			SceneManager.LoadScene(mainMenu);
			break;
		}	
	}
}
