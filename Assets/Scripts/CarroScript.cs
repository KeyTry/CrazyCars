﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroScript : MonoBehaviour {

	public float speed;	
	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 movement = new Vector3 (0.0f, 0.0f, 
//			transform.forward * speed);

		rb.velocity = transform.forward * speed;
	}
}