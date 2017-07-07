using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EagleController : MonoBehaviour
{
	public float bigSpeed;
	public float upForce;
	public float forwardForce;
	public Transform planet;
	public float airResistanceStregth;
	public float planetGravity;
	public Text healthText;
	public Text rabbitNumText;
	private int rabbitNum = 0;
	private int health = 50;
	public GameObject bigClaw;
	public Image blood;
	public Image hurted;
	public GameObject sceneManager;

	CursorLockMode wantedMode;
	public Camera myCam;

	private float bloodTimer = 1.0f;

	public AudioSource tearing;
	public AudioSource hitTree;
	public AudioSource flapSound;
	private float diveFactor;

	public ParticleSystem trace;

	// Use this for initialization
	void Start () { 
		wantedMode = CursorLockMode.Locked;
		Cursor.lockState = wantedMode;

		blood.CrossFadeAlpha (0f, 0f, true);
		hurted.CrossFadeAlpha (0f, 0f, true);
		EagleCollider.hurting = false;
		bloodTimer = 1f;
	}

	void Update()
	{
		float vel = gameObject.GetComponent<Rigidbody> ().velocity.magnitude;

		rabbitNumText.text = "Rabbit killed: " + rabbitNum.ToString();
		//healthText.text = "Health: " + health.ToString ();
		if (vel > 80f) {
			trace.Play ();
		} else {
			trace.Stop ();
		}

		// Check buncing 
		float distance = Vector3.Distance (transform.position, planet.position);
		if (distance < 400f) {
			//bouncing (); // no more bouncing
		}

		// If kill more than 4 go to next scene.
		if (rabbitNum > 4) {
			Debug.Log(rabbitNum);
			sceneManager.GetComponent<NextScene> ().jumpScene("06EagleToMusic");
			Cursor.lockState = CursorLockMode.None;
		}

		// you die
		if (health <= 0) {
			sceneManager.GetComponent<NextScene> ().jumpScene("06EagleToMusic");
		}

		// Ground normal
		Vector3 groundNormal = transform.position-planet.transform.position;
		// Local forward
		Vector3 localForward = -Vector3.Cross (groundNormal, transform.right).normalized;
		transform.rotation = Quaternion.LookRotation (localForward, groundNormal);
		float rotationspeed = 100f;
		transform.RotateAround(transform.position, transform.up,  Time.deltaTime * Input.GetAxis("Mouse X") * rotationspeed);

		// Dive factor
		diveFactor = Mathf.Abs(Vector3.Dot(-groundNormal.normalized,myCam.transform.forward))+3.0f;
		diveFactor *= diveFactor;

		healthText.text = "Health: " + health.ToString ();

		// Gravity 
		gameObject.GetComponent<Rigidbody> ().useGravity = false;
		// Player -> Planet core
		gameObject.GetComponent<Rigidbody> ().AddForce((planet.position - transform.position).normalized * 10.0f);

		RaycastHit canHit; 
		if (Physics.Raycast (myCam.transform.position, myCam.transform.forward, out canHit, 12f)) {
			if (canHit.transform.gameObject.tag == "RedRabbit") {
				bigClaw.SetActive (true);
			}
		} else {
			bigClaw.SetActive (false);
		}

		// Hitting mechanism
		RaycastHit hit; 
		if (Input.GetMouseButton (0)) {
			if (Physics.Raycast (myCam.transform.position, myCam.transform.forward, out hit, 12f)) {
				if (hit.transform.gameObject.tag == "RedRabbit") {
					hit.transform.gameObject.GetComponent<RedRabbit> ().bloodSplashing ();
					hit.transform.gameObject.GetComponent<RedRabbit> ().bloodPooling ();
					Destroy (hit.transform.gameObject);
					tearing.Play ();
					rabbitNum += 1;
					health += 5;
				}
			}
		}

		if (EagleCollider.hurting == true) {
			hurted.CrossFadeAlpha (1, 0.2f, true);
		} else {
			hurted.CrossFadeAlpha (0, 0.2f, true);
		}
	}


	void FixedUpdate(){
		// Air resistance
		// F = ((air density)(drag)(area)/2)*(velocity)^2
		Vector3 currVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
		float airRisitanceForceValue = (1.225f * 0.06f * 2.0f / 2) * currVelocity.sqrMagnitude;
		Vector3 risistanceForce = airRisitanceForceValue * (-currVelocity.normalized);

		if (Vector3.Distance (transform.position, planet.position) < 1000f) {
			gameObject.GetComponent<Rigidbody> ().AddForce (myCam.transform.forward * forwardForce*diveFactor, ForceMode.Force);
		}
		gameObject.GetComponent<Rigidbody> ().AddForce (risistanceForce);

		// Keyboard space to control UP force
		if (Input.GetKeyDown ("space")&&Vector3.Distance (transform.position, planet.position) < 1000f) {
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 1200f, ForceMode.Force);
			flapSound.Play ();
		}
	}

	public void getDamaged(){
		health -= 10;
		if (health < 0) {
			health = 0;
		}
		hitTree.Play ();
	}

	/*
	private void bouncing(){
		float bouncingForce = 1200f;
		Vector3 currVelocity = gameObject.GetComponent<Rigidbody> ().velocity;
		Vector3 newVelocity = new Vector3 (currVelocity.x, 0f, currVelocity.z);

		gameObject.GetComponent<Rigidbody> ().velocity = newVelocity;
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * bouncingForce, ForceMode.Impulse);
	}*/
}