using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a 2d Character controller using the CharacterController component. 
//I used the Unity Documentation here: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
//as a base.
//


public class PlayerController2d : MonoBehaviour
{
	private CharacterController controller;
	public Vector3 playerVelocity;
	private bool groundedPlayer;
	private float playerSpeed = 4.0f;
	private float jumpHeight = 2.0f;
	private float gravityValue = -7.0f; //change this to make it more floaty

	private void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
	}


	void Update()
	{
		groundedPlayer = controller.isGrounded; //this uses the Character Controllers built in .isGrounded function to detect if the gameobject is on the ground.
		if (groundedPlayer && playerVelocity.y <= 0)
		{
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0); //we only need the horizontal axis since we are only moving left and right.
		controller.Move(move * Time.deltaTime * playerSpeed);

		//if move has any value at all...
		if (move != Vector3.zero)
		{
			gameObject.transform.forward = move; 
		}

		// Changes the height position of the player..
		if (Input.GetButton("Jump") && groundedPlayer)
		{
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}
		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);
	}

}