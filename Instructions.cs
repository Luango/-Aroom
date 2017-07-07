using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	enum instructions {water, love, window, door, potion, glassBall, cryBaby, xinCheng, la, freedom, theDefault, theGirl};

	public Material[] materials;
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Renderer> ().material = materials [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (EnterGalssBallTrigger.entered == false) {
			switch (PlayerController.instructNum) {
			case (int)instructions.water:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.water];
				break;
			case (int)instructions.love:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.love];
				break;
			case (int)instructions.window:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.window];
				break;
			case (int)instructions.door:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.door];
				break;
			case (int)instructions.potion:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.potion];
				break;
			case (int)instructions.glassBall:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.glassBall];
				break;
			case (int)instructions.cryBaby:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.cryBaby];
				break;
			case (int)instructions.xinCheng:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.xinCheng];
				break;
			case (int)instructions.la:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.la];
				break;
			case (int)instructions.freedom:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.freedom];
				break;
			default:
				gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.theDefault];
				break;
			}
		} else if (PlayerController.instructNum == (int)instructions.theGirl) {
			gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.theGirl];
		} else {
			gameObject.GetComponent<Renderer> ().material = materials [(int)instructions.theDefault];
		}
	}
}
