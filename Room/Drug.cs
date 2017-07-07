using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour {
	public static bool isMeeting=false;
	public GameObject shrinkPotion;

	void Start(){
		if (!isMeeting) {
			// if meeting show the potion, if not do not show the potion
			gameObject.SetActive (false);
		}
	}

	void Update(){
		if (DrugEffects.DrugFlag == 1 && gameObject.activeSelf == true) {
			gameObject.SetActive (false);
		}
	}

	public void drinkPotion(){
		DrugEffects.DrugFlag = 1;
		PlayerController.drunkPotion = true;
	}

	public void isMeetingAgain(){
		isMeeting = true;
	}
}
