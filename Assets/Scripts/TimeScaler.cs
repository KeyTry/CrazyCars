using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour {
	private float input;
    public Rigidbody car;
	void Start(){
		Time.timeScale = 0.4f;
	}
	void FixedUpdate () {
		input = Input.GetAxis ("Vertical");

        if (input > 0)
        {
            Time.timeScale = 0.6f;
        }
        if (input == 0)
        {
            Time.timeScale = 0.5f;
        }
        if (input < 0)
        {
            Time.timeScale = 0.2f;
            if (car.velocity.magnitude == 0)
            {
                Time.timeScale = 0.05f;
            }
        }

        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
