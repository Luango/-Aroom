using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBall : MonoBehaviour {
	public GameObject seeingGlass, noSeeingGlass;
	// Use this for initialization
	void Start () {
		if (Drug.isMeeting) {
			seeingGlass.SetActive (true);
			noSeeingGlass.SetActive (false);
		} else {
			noSeeingGlass.SetActive (true);
			seeingGlass.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
