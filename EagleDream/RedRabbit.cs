using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RedRabbit : MonoBehaviour {
	private float velocity;
	public Transform planet;
	public float planetGravity;

	public GameObject bloodPool;
	public GameObject bloodSplash;

	// Use this for initialization
	void Start () {
		velocity = Random.Range (10f, 15f);
	} 

	void FixedUpdate(){
		// Vertical to the planet
		Vector3 groundNormal = transform.position-planet.transform.position;
		Vector3 localForward = -Vector3.Cross (groundNormal, transform.right).normalized;
		transform.rotation = Quaternion.LookRotation (localForward, groundNormal);

		// Gravity 
		gameObject.GetComponent<Rigidbody> ().useGravity = false;
		// Player -> Planet core
		gameObject.GetComponent<Rigidbody> ().AddForce((planet.position - transform.position) * planetGravity);
		gameObject.GetComponent<Rigidbody> ().velocity = transform.forward*velocity;
	}

	public void bloodSplashing(){
		GameObject theObject = (GameObject)Instantiate (bloodSplash, transform.position, transform.rotation);
		theObject.transform.localScale = new Vector3 (20f, 20f, 20f);
		Debug.Log ("splashing");
	}

	public void bloodPooling(){
		// Keep the gameobject perpendicular on the point of the sphere surface
		GameObject theObject = (GameObject)Instantiate(bloodPool, transform.position, Quaternion.identity);
		Vector3 groundNormal = theObject.transform.position-planet.transform.position;
		Vector3 localForward = -Vector3.Cross (groundNormal, theObject.transform.right).normalized;
		theObject.transform.rotation = Quaternion.LookRotation (localForward, groundNormal);
	}
}
