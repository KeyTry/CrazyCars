﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroUser : MonoBehaviour {

	public float maxSpeed = 5.0f; // in metres per second
	public float minSpeed = 0f; // in metres per second

	public float acceleration = 5.0f; // in metres/second/second
	public float brake = 5.0f; // in metres/second/second
	public float turnSpeed = 30.0f; // in degrees/second

	private Vector3 velocity; // in metres per second
	private float speed;    // in metres/second
	private float turn;
	private float forwards;
	private Rigidbody rigidbody;

	void Awake(){
		rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		// the horizontal axis controls the turn
		turn = Input.GetAxis("Horizontal");
		// turn the car
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		// the vertical axis controls acceleration fwd/back

		forwards = Input.GetAxis("Vertical");

		if (forwards > 0) {
			// accelerate forwards
			speed = speed + acceleration;
		}
		else if (forwards < 0) {
			// accelerate backwards
			speed = speed - acceleration;
		}
		else {
			// braking
			if (speed > 0) {
				speed = speed - brake;
			}
		}

		// clamp the speed
		speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
		// compute a vector in the up direction of length speed
		velocity = Vector3.forward * speed;
		// move the object
		//transform.Translate(velocity * Time.deltaTime, Space.Self);
	}

	void FixedUpdate(){
		
		rigidbody.AddForce( velocity);
		
	}

}