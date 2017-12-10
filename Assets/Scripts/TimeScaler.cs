using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour {
	private float input;
	void Start(){
		Time.timeScale = 0.4f;
	}
	void Update () {
		input = Input.GetAxis ("Vertical");

		if (input > 0) {
			Time.timeScale = 0.4f;
		} else if (input < 0) {
			Time.timeScale = 0.2f;
		}
	}
}
