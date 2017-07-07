using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDummyNote : MonoBehaviour {
	private int chasePhase; // 0 do nothing; 1 raise; 2 chase;
	private float speed=7.5f;
	public GameObject closestNote;
	private bool foundClosest=false;
	private float heightThreshold;

	public static int touchCount = 0;
	private float distanceToNote;

	public AudioSource collidingSound;

	// Use this for initialization
	void Start () {
		distanceToNote = 10000f;
		heightThreshold = Random.Range (70f, 90f);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.transform.tag == "Player" && chasePhase == 0) {
			chasePhase = 1; // start raising
			touchCount++;
			collidingSound.Play ();
		} 
		if (collider.transform.tag == "MusicNote"&&distanceToNote<0.5f) {
			collider.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			collider.gameObject.transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = true; // Mesh renderer active
			collider.gameObject.GetComponent<MusicNote>().activeNote();
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (touchCount > 1115 && chasePhase == 0) {
			chasePhase = 1;
		}
		else if (chasePhase == 1) {
			Raise ();
			if (transform.position.magnitude > heightThreshold) {
				chasePhase = 2;
				//Debug.Log ("Phase 2");
			}
		}
		else if (chasePhase == 2) {
			// Start chasing the note
			// Find the closest note
			// Chase the note
			if (!foundClosest) {
				FindClosestNote ();
			} else {
				// Chase
				ChaseNote();
			}
		}
	}

	void Raise(){
		transform.Translate (Vector3.up * Time.deltaTime * speed);
	}

	void FindClosestNote(){
		GameObject MusicManager = (GameObject)GameObject.Find ("PlanetMusicManager");

		// Reach the list
		List<GameObject> musicNotesList = MusicManager.GetComponent<PlanetMusicManager> ().musicNotesList;

		// Find the the closest note
		float minDis = 1000f;
		GameObject closestObj=null;
		foreach (GameObject curr in musicNotesList) {
			float currDis = Vector3.Distance (curr.transform.position, transform.position);
			if (currDis < minDis) {
				minDis = currDis;
				closestObj = curr;
			}
		}
		if (closestObj != null) {
			closestNote = closestObj;
		}

		// Remove this Transform
		musicNotesList.Remove(closestObj);
		foundClosest = true;
	}

	void ChaseNote(){
		// move to closestNote
		Vector3 directionVector = (closestNote.transform.position - transform.position);
		distanceToNote = directionVector.magnitude;
		Vector3 normalizedDirection = (directionVector).normalized;
		transform.position = transform.position + normalizedDirection * speed * Time.deltaTime;
	}
}
