using UnityEngine;
using System.Collections;

public class MoveDestination : MonoBehaviour {
	Renderer rend;
	public static bool notTouched = true;
	Color curr; 
	public GameObject thisEffect;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () { 
		if (PlayerController.drunkPotion == true) {
			if (thisEffect != null) {
				thisEffect.SetActive (true);
			}
		}
	}
}
