using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarColor : MonoBehaviour {
	public Color[] colors = new Color[6];
	// Use this for initialization
	void Awake () {
		colors[0] = Color.cyan;
		colors[1] = Color.red;
		colors[2] = Color.green;
		colors[3] = Color.white;
		colors[4] = Color.yellow;
		colors[5] = Color.magenta;
		int randomNo = (int)Random.Range (0,6);
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_EmissionColor", colors[randomNo]);
	} 
}
