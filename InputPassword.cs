using UnityEngine;
using System.Collections;

public class InputPassword : MonoBehaviour {
	public string stringToEdit = "Hello World";
	void OnGUI() {
		stringToEdit = GUI.TextField(new Rect(10, 10, 200, 220), stringToEdit, 225);
	}
}
