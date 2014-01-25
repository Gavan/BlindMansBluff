using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Credits Screen");

		// Make the back button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Back")) {
			Application.LoadLevel("MainMenu");
		}
		
	}
}

