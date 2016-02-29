﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompleteCameraController : MonoBehaviour {

	public GameObject player;		//Public variable to store a reference to the player game object



	private Vector3 offset;			//Private variable to store the offset distance between the player and camera


	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
		this.enabled = false;
		
	}
	
	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		offset.z = -20;	
		transform.position = player.transform.position + offset;
			
	}
}
