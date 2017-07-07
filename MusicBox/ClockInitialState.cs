using UnityEngine;
using System.Collections;

public class ClockInitialState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] clockMusicBars = GameObject.FindGameObjectsWithTag ("ClockMusicBar");
		foreach (GameObject theMusicBar in clockMusicBars) {
			theMusicBar.GetComponent<AudioSource> ().volume = 0.0f;
		}
		clockMusicBars = GameObject.FindGameObjectsWithTag ("PlanetMusicBar");
		foreach (GameObject theMusicBar in clockMusicBars) {
			theMusicBar.GetComponent<AudioSource> ().volume = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
