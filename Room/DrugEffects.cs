using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugEffects : MonoBehaviour {
	public GameObject drugLight;
    public static int DrugFlag = -1;  // -1 before drug , 0 using drug 
    public int shrinkSpeed = 1;
    public float targetScale = 0.1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(DrugFlag == 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale*0.1f, targetScale), Time.deltaTime * shrinkSpeed);
			StartCoroutine(potionEffects());
        }	
	}
	IEnumerator potionEffects(){
		if (drugLight != null) {
			drugLight.SetActive (true);
		}
		yield return new WaitForSeconds(2.5f);
		Destroy (drugLight);
	}
}
