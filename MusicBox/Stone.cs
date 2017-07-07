using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {
	public static int stoneCounter;
	public GameObject stoneParticle;
	public Transform particleTrnsform;
	public Color stoneColor;
	public Light theLight;
	public GameObject sceneManager;

	private float musicPlayTime = 5f;
	private bool isTouched;
	// Use this for initialization
	void Start () {
		isTouched = false;
		stoneCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTouched && theLight.intensity > 0f) {
			theLight.intensity -= 0.06f;
		}

		if (stoneCounter > 6) {
			musicPlayTime -= Time.deltaTime;
			if (musicPlayTime < 0f) {
				sceneManager.GetComponent<NextScene> ().nextScene ();
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player"&&!isTouched) {
			gameObject.GetComponent<Renderer> ().material.color = stoneColor;
			stoneCounter++;
			isTouched = true;
			Instantiate (stoneParticle, particleTrnsform.position, Quaternion.identity);
			if (stoneCounter > 6) {
				turnOnStarsBar ();
			}
		}
	}
	void turnOnStarsBar(){
		GameObject[] clockMusicBars = GameObject.FindGameObjectsWithTag ("PlanetMusicBar");
		foreach (GameObject theMusicBar in clockMusicBars) {
			theMusicBar.GetComponent<AudioSource> ().volume = 0.2f;
		}
	}
}
