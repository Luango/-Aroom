using UnityEngine;
using System.Collections;

public class CameraSkyBox : MonoBehaviour {
	private float exposure = 4f;
	
	// Update is called once per frame
	void Update () {
		if (EnterGalssBallTrigger.entered) {
			if (exposure > 1.0f) {
				exposure -= 0.02f;
				RenderSettings.skybox.SetFloat ("_Exposure", exposure);
			}
		}
	}
}
