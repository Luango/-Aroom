using UnityEngine;

public class PlayerController : MonoBehaviour
{
	enum instructions {water, love, window, door, potion, glassBall, cryBaby, xinCheng, la, freedom, theDefault, theGirl};
	public float bigSpeed;
	public static bool drunkPotion=false;
	public static int instructNum=(int)instructions.theDefault;
	public Transform planet;
	public bool onPlanet;
	public LayerMask interactiveMask;
	public float scale_x, scale_y, scale_z;

	public Camera myCam;
	static public bool moveable;

	// Use this for initialization
	void Start () { 
		EnterGalssBallTrigger.entered = false;
		DrugEffects.DrugFlag = -1;
		Cursor.lockState = CursorLockMode.Locked;
		transform.localScale = new Vector3 (scale_x, scale_y, scale_z);
		moveable = true;
	}

	// Freeze character
	public void fixCharacter(){
		moveable = false;
	}

	// Free character
	public void freeCharacter(){
		moveable = true;
	}

	void Update()
	{ 
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");

		// Copy the camera's rotation.
		// Camera rotation outside the glassball planet.
		if (moveable) {
			if (EnterGalssBallTrigger.entered == false && onPlanet == false) {
				Vector3 move = new Vector3 (x, 0, z);
				move = move.normalized * Time.deltaTime * 0.2f * bigSpeed * transform.localScale.x;
				transform.Translate (move, Space.Self);
				float rotationspeed = 100f;
				transform.RotateAround (transform.position, transform.up, Time.deltaTime * Input.GetAxis ("Mouse X") * rotationspeed);
			} else {
				Vector3 move = new Vector3 (x, 0, z);
				move = move.normalized * Time.deltaTime * 0.2f * bigSpeed * transform.localScale.x;
				transform.Translate (move, Space.Self);

				// Ground normal
				Vector3 groundNormal = transform.position - planet.transform.position;
				Vector3 localForward = -Vector3.Cross (groundNormal, transform.right).normalized;
				transform.rotation = Quaternion.LookRotation (localForward, groundNormal);
				float rotationspeed = 100f;
				transform.RotateAround (transform.position, transform.up, Time.deltaTime * Input.GetAxis ("Mouse X") * rotationspeed);
			}
		}

		// Gravity 
		if (EnterGalssBallTrigger.entered == true||onPlanet) {
			gameObject.GetComponent<Rigidbody> ().useGravity = false;
			// Player -> Planet core
			gameObject.GetComponent<Rigidbody> ().AddForce((planet.position - transform.position).normalized * 10f);
		}
	}
}