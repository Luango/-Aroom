using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDummyManager : MonoBehaviour {
	[System.Serializable]
	public class PlanetObj
	{
		public GameObject objType;
		public float radius;
		public int num;
		public float minSize, maxSize;
	} 

	// The centre of the planet
	public Transform planet;
	public List<PlanetObj> objects;
	public Transform playerTrans;
	public List<GameObject> dummyList;

	private float time = 0.2f;

	// Instantiate part of the music notes.
	void Start () {
		foreach (PlanetObj aPlanetObj in objects) {
			while (aPlanetObj.num > 0) {
				float x0, x1, x2, x3;
				// Instantiate random unit quaternion
				x0 = Random.Range (-1.0f, 1.0f);
				x1 = Random.Range (-1.0f, 1.0f);
				x2 = Random.Range (-1.0f, 1.0f);
				x3 = Random.Range (-1.0f, 1.0f);

				if (x0 * x0 + x1 * x1 + x2 * x2 + x3 * x3 < 1f) {
					float x, y, z;
					float square = x0 * x0 + x1 * x1 + x2 * x2 + x3 * x3;
					x = 2 * (x1 * x3 + x0 * x2) / square;
					y = 2 * (x2 * x3 - x0 * x1) / square;
					z = (x0 * x0 + x3 * x3 - x1 * x1 - x2 * x2) / square;

					// Random rotation vector in y-axis
					Vector3 iniRot = new Vector3 (0f, Random.Range (0, 360), 0f);
					Vector3 position = new Vector3 (x, y, z) * aPlanetObj.radius;
					if (Vector3.Distance (playerTrans.position, position)>20f) {
						aPlanetObj.num--;
						// Instantiate game object with a range of scale
						GameObject theObject = (GameObject)Instantiate (aPlanetObj.objType, new Vector3 (x, y, z) * aPlanetObj.radius*Random.Range(1.0f, 1.1f), Quaternion.Euler (iniRot));
						float randomScale = Random.Range (aPlanetObj.minSize, aPlanetObj.maxSize);
						theObject.transform.localScale = new Vector3 (randomScale, randomScale, randomScale);

						// Keep the gameobject perpendicular on the point of the sphere surface
						Vector3 groundNormal = theObject.transform.position - planet.transform.position;
						Vector3 localForward = -Vector3.Cross (groundNormal, theObject.transform.right).normalized;
						theObject.transform.rotation = Quaternion.LookRotation (localForward, groundNormal);
						theObject.SetActive (false);
						dummyList.Add (theObject);
					}
				}
			}
		}
	}

	// Other music notes add later
	void Update(){
		time -= Time.deltaTime;
		if (time < 0) {
			int i = 0;
			foreach (GameObject aPlanetObj in dummyList) {
				i++;
				if (aPlanetObj!=null && aPlanetObj.activeSelf == false) {
					aPlanetObj.SetActive (true);

					time = 0.5f/i;
					break;
				}
			}
		}
	}
	/*
	void Update(){
		float x0, x1, x2, x3;

		// Instantiate random unit quaternion
		x0 = Random.Range (-1.0f, 1.0f);
		x1 = Random.Range (-1.0f, 1.0f);
		x2 = Random.Range (-1.0f, 1.0f);
		x3 = Random.Range (-1.0f, 1.0f);

		if (x0 * x0 + x1 * x1 + x2 * x2 + x3 * x3 < 1f) {
			float x, y, z;
			float square = x0 * x0 + x1 * x1 + x2 * x2 + x3 * x3;
			x = 2 * (x1 * x3 + x0 * x2) / square;
			y = 2 * (x2 * x3 - x0 * x1) / square;
			z = (x0 * x0 + x3 * x3 - x1 * x1 - x2 * x2) / square;

			// Random rotation vector in y-axis
			Vector3 iniRot = new Vector3 (0f, Random.Range (0, 360), 0f);
			Vector3 position = new Vector3 (x, y, z) * aPlanetObj.radius;
			if (Vector3.Distance (playerTrans.position, position)>20f) {
				aPlanetObj.num--;
				// Instantiate game object with a range of scale
				GameObject theObject = (GameObject)Instantiate (aPlanetObj.objType, new Vector3 (x, y, z) * aPlanetObj.radius, Quaternion.Euler (iniRot));
				float randomScale = Random.Range (aPlanetObj.minSize, aPlanetObj.maxSize);
				theObject.transform.localScale = new Vector3 (randomScale, randomScale, randomScale);

				// Keep the gameobject perpendicular on the point of the sphere surface
				Vector3 groundNormal = theObject.transform.position - planet.transform.position;
				Vector3 localForward = -Vector3.Cross (groundNormal, theObject.transform.right).normalized;
				theObject.transform.rotation = Quaternion.LookRotation (localForward, groundNormal);
			}
		}
	}
	*/
}
