using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingTowardPlayer : MonoBehaviour {
    public GameObject player;

	// Update is called once per frame
	void Update () {
        // GameObject facing player
        gameObject.transform.LookAt(player.transform);
	}
}
