using UnityEngine;
using System.Collections;

public class MusicLightManager : MonoBehaviour {
	public Light spiritLight;
	public Light lightBeam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Stone.stoneCounter > 6 && spiritLight.intensity < 0.6f) {
			spiritLight.intensity += 0.005f;
		}
		if (Stone.stoneCounter > 6 && lightBeam.intensity < 4f) {
			lightBeam.intensity += 0.01f;
		}
	}
}
