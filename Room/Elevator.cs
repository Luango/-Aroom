using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update() {
        if (PlayerController.drunkPotion == true)
        {
            Vector2 player_pos = new Vector2(player.transform.position.x, player.transform.position.z);
            Vector2 light_pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);

            float distance_2d = Vector2.Distance(player_pos, light_pos);
            Debug.Log(player.GetComponent<Rigidbody>().velocity.magnitude < 1f);
            if (distance_2d < 0.1f && player.GetComponent<Rigidbody>().velocity.magnitude<1f)
            {
                //player.transform.Translate(0f, 0.05f, 0f);
                player.GetComponent<Rigidbody>().AddForce(Vector3.up*9, ForceMode.Acceleration);
            }
        }
    }

    void OnTriggerEnter(Collider other){

    }


}
