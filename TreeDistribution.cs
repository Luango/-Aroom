using UnityEngine;
using System.Collections;

public class TreeDistribution : MonoBehaviour {
	public int numberOfTrees;
	private float x1, x2, x3, x0;
	public GameObject[] treeTypes;

	// Use this for initialization
	void Start () {
		while (numberOfTrees > 0) {
			// Pick four numbers from a uniform distribution on (-1, 1)
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
				numberOfTrees--;
				int treeTypeNo = (int)Random.Range (0f, 3f);
				Vector3 iniRot = new Vector3 (0f, Random.Range (0, 360), 0f);
				GameObject theTree = (GameObject)Instantiate(treeTypes[treeTypeNo], new Vector3(x,y,z)*385f, Quaternion.Euler(iniRot));
				float randomScale = Random.Range (1f, 10f);
				theTree.transform.localScale = new Vector3 (randomScale, randomScale, randomScale);
			}
		}
	}
}
