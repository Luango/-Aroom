using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
	static public string NextSceneName;
	static public bool isLoadScene;
	// Use this for initialization
	void Start(){
		isLoadScene = false;
	}
	void Update(){
		if (isLoadScene==true&&FadeInOut.isFadeOut) { 
			SceneManager.LoadScene (NextSceneName, LoadSceneMode.Single);
			isLoadScene = false;
		}
	}
	public void nextScene () {
		isLoadScene = true;
	}
	public void jumpScene(string a){
		isLoadScene = true;
		NextSceneName = a;
	}
}
