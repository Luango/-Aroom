using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterManager : MonoBehaviour {
	public GameObject character;
	public int count = 100;
	//private float deltaTime = 0.5f;
	private float radius = 2.5f;
	public List<GameObject> charactersList;

	void Awake() {
		for (int i = 0; i < 80; i++) {
			float rot = Random.Range (0, 360);
			GameObject cnChar = Instantiate(character, new Vector3(Mathf.Cos(rot)*radius + Random.Range(-0.5f,0.5f), Mathf.Sin(rot)*radius*2.0f+1.00f + Random.Range(-0.5f,0.5f), 0), Quaternion.Euler(0, 0, rot)) as GameObject;
			float randomSize = Random.Range (0.05f, 0.2f);
			cnChar.transform.localScale = new Vector3 (randomSize, randomSize, 0);
			charactersList.Add (cnChar);
		}

		for (int i = 0; i < 180; i++) {
			float rot = Random.Range (0, 360);
			GameObject cnChar = Instantiate(character, new Vector3(Mathf.Cos(rot)*radius*2.5f + Random.Range(-1.3f,1.3f), Mathf.Sin(rot)*radius*2.5f+1.00f + Random.Range(-0.8f,0.8f), 0), Quaternion.Euler(0, 0, rot)) as GameObject;
			float randomSize = Random.Range (0.15f, 0.3f);
			cnChar.transform.localScale = new Vector3 (randomSize, randomSize, 0);
			charactersList.Add (cnChar);
		}


		for (int i = 0; i < 80; i++) {
			float rot = Random.Range (0, 360);
			GameObject cnChar = Instantiate(character, new Vector3(Mathf.Cos(rot)*radius*4.14f, Mathf.Sin(rot)*radius*4.14f+1.00f, 0), Quaternion.Euler(0, 0, rot)) as GameObject;
			float randomSize = Random.Range (0.05f, 0.2f);
			cnChar.transform.localScale = new Vector3 (randomSize, randomSize, 0);
			charactersList.Add (cnChar);
		}
	}
}
