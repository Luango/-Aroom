using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour {
	public float rotateSpeed;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (Time.deltaTime * rotateSpeed, 0f, 0f));
	}
}
