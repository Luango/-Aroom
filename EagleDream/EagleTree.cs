using UnityEngine;
using System.Collections;

public class EagleTree : MonoBehaviour {
	private float velocity;
	public Transform planet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 groundNormal = transform.position-planet.transform.position;
		Vector3 localForward = -Vector3.Cross (groundNormal, transform.right).normalized;
		transform.rotation = Quaternion.LookRotation (localForward, groundNormal);
	}
}
