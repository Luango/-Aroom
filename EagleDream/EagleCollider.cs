using UnityEngine;
using System.Collections;

public class EagleCollider : MonoBehaviour {
	public GameObject eagle;
	static public bool hurting = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.gameObject.tag == "Tree") {
			eagle.GetComponent<EagleController> ().getDamaged ();
			hurting = true;
			StartCoroutine (stopHurting ());
		}
	}
	IEnumerator stopHurting(){
		yield return new WaitForSeconds (0.2f);
		hurting = false;
	}
}
