using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {
	public Image fadeIn;
	public Image fadeOut;
	public Image Title;
	float alpha;
	bool starting;
	bool startFadeIn;
	static public bool isFadeOut;

	void Start(){
		starting = true;
		startFadeIn = true;
		isFadeOut = false;
	}

	// Update is called once per frame
	void Update () {
		// Fade in once the scene is generated.
		if (starting == true) {
			Color tempColor = fadeIn.color;
			Color titleColor = Title.color;
			if (startFadeIn == true) {
				if (titleColor.a < 0.99f) {
					titleColor.a += Time.deltaTime * 0.2f;
					Title.color = titleColor;
				} else {
					startFadeIn = false;
				}
			} else {
				if (tempColor.a > 0.00f) {
					tempColor.a -= Time.deltaTime * 0.2f;
					fadeIn.color = tempColor;
				}
				if (titleColor.a > 0.00f) {
					titleColor.a -= Time.deltaTime * 0.4f;
					Title.color = titleColor;
				}
				if (tempColor.a < 0.01f) {
					starting = false;
				}
			}
		}

		// Fade out when trigger the next scene
		if (NextScene.isLoadScene == true) {
			Color tempColor = fadeOut.color;
			if (tempColor.a < 0.999f && starting == false) { 
				tempColor.a += Time.deltaTime * 0.3f;
				fadeOut.color = tempColor;
			} else {
				isFadeOut = true;
			}
		}
	} 
}
