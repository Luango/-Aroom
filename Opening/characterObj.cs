using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterObj : MonoBehaviour {
	public TextAsset characters;

	private Vector3 direction;
	private Color currColor;
	public bool isFadeIn;
	private float fadeSpeed;
	private Vector3 bornPosition;
	// Use this for initialization
	void Start () {
		bornPosition = gameObject.transform.position;
		createChar ();
	}

	void Update(){
		gameObject.transform.Translate (direction*Time.deltaTime*0.1f*Random.Range(0.2f, 0.8f), Space.World);

		if (isFadeIn) {
			currColor.a += Time.deltaTime*fadeSpeed;
			if (currColor.a > 0.9f) {
				isFadeIn = false;
			}
		} else {
			currColor.a -= Time.deltaTime*fadeSpeed;
			if (currColor.a < 0.05f) {
				createChar ();
			}
		}
		GetComponent<TextMesh> ().color = currColor;
	}

	private void createChar(){
		gameObject.transform.position = bornPosition;
		isFadeIn = true;
		string[] charsInFile = characters.text.Split(' ');
		int numChar = (int)Random.Range(0, charsInFile.Length-1);
		GetComponent<TextMesh> ().text = charsInFile[numChar];
		direction = transform.position - new Vector3 (0f, 0f, 0f);
		direction.Normalize ();
		currColor = Color.black;
		currColor.a = 0;
		GetComponent<TextMesh> ().color = currColor;
		fadeSpeed = Random.Range (0.1f, 0.5f);
	}
}
