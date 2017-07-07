using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EagleDeathSceneManager : MonoBehaviour {
	void Start(){
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void wakeUp(){
		SceneManager.LoadScene ("ARoom", LoadSceneMode.Single);
	}

	public void reSleep(){
		Debug.Log ("Click");
		SceneManager.LoadScene ("EagleDream", LoadSceneMode.Single);
	}
}
