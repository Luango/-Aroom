using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomColorControl : MonoBehaviour {
	public GameObject room;
	public GameObject pillow;
	public GameObject bed;
	public GameObject table;

	private Renderer roomRend;
	private Renderer pillowRend;
	private Renderer bedRend;
	private Renderer tableRend;

	private Color roomColor;
	private Color pillowColor;
	private Color bedColor;
	private Color tableColor;

	static float t = 0.0f;
	public Color targetColor;
	private Color originalColor;

	// Use this for initialization
	void Start () {
		roomRend = room.GetComponent<Renderer> ();
		pillowRend = pillow.GetComponent<Renderer> ();
		bedRend = bed.GetComponent<Renderer> ();
		tableRend = table.GetComponent<Renderer> ();
		originalColor = roomRend.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(DrugEffects.DrugFlag == 1){
			float lerp = Mathf.Lerp(0f,1f,t);
			roomRend.material.color = Color.Lerp (originalColor, targetColor, lerp);
			pillowRend.material.color = Color.Lerp (originalColor, targetColor, lerp);
			bedRend.material.color = Color.Lerp (originalColor, targetColor, lerp);
			tableRend.material.color = Color.Lerp (originalColor, targetColor, lerp);

			t += 0.5f * Time.deltaTime;
		}
	}
}
