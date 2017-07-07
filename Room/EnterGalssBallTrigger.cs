using UnityEngine;
using System.Collections;

public class EnterGalssBallTrigger : MonoBehaviour {
	public GameObject[] roomObjects;
	public GameObject[] glassBallObjects;
	public static bool entered = false;
	public float duration = 2.0f;
	public Light lt;
	private float deltaTime=2.0f;
	//private float exposure = 4.0f;
	public GameObject planet;
	public GameObject[] planetObjects;

	// Use this for initialization
	void Start () {
		roomObjects = GameObject.FindGameObjectsWithTag ("Room");
	}
	
	// Update is called once per frame
	void Update () {
		if (entered) {
			if (deltaTime > 0) {
				float phi = Time.time / duration * 2 * Mathf.PI;
				float amplitude = Mathf.Cos (phi) * 6.5F + 0.5F;
				lt.intensity = amplitude;
				deltaTime -= Time.deltaTime;

			} else {
				Destroy (lt);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			entered = true;
			StartCoroutine (OutDelay ());
			planet.SetActive (true);

			foreach (GameObject glassBallObject in planetObjects) {
				if (glassBallObject != null) {
					glassBallObject.SetActive (true);
				}
			}
		}
	}
	IEnumerator OutDelay()
	{
		yield return new WaitForSeconds (0.5f);
		foreach (GameObject roomObject in roomObjects) {
			if (roomObject != null) {
				roomObject.SetActive (false);
			}
		}
	}
}
