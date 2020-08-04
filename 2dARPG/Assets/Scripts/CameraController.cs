using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//Variables
	GameObject player; //the player's gameobject
	Vector3 offset;    //offset for the camera follow

	void Awake(){
		//finds the gameobject in the scene with the Player tag and assigns it
		player = GameObject.FindGameObjectWithTag ("Player");
		//initial offset is set
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		//remember transform (lowercase) refers to the transform of the game object that this script is attached to.
		transform.position = player.transform.position + offset;
	}
}