//C#
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(Screen.width/2,10,100,90), "Main Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2+10,40,80,20), "Start Game")) {
			Application.LoadLevel("Map");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width/2+10,70,80,20), "Credits")) {
			Application.LoadLevel("Credits");
		}
	}
}