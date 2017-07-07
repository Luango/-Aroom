using UnityEngine;
using System.Collections;

public class ClockArmRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ClockSwitch.isOn){
			transform.Rotate(new Vector3(-0.2f,0f,0f));
		}
	}
}
