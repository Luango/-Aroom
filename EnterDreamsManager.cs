using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDreamsManager : MonoBehaviour {
	public string[] dreamNames;
	// Use this for initialization
	public void enterDream(){
		int dreamNum = dreamNames.Length;
		float randomNum = Random.Range (0, (float)dreamNum);
		//Application.LoadLevel(dreamNames[(int)randomNum]);
		SceneManager.LoadScene (dreamNames[(int)randomNum], LoadSceneMode.Single);
	}
}
