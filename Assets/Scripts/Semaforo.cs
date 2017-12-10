using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Semaforo : MonoBehaviour {

	public Image[] colors;

	public Rigidbody player;
	float currentSpeed;

	// Use this for initialization
	void Start () {
		blankColors ();
	}
	
	// Update is called once per frame
	void Update () {
		currentSpeed = player.velocity.magnitude;
		if(currentSpeed > 7f){
			blankColors ();
			colors [1].color = new Color (178,25,53,255);
			Debug.Log ("Rapido");
		}
		if (currentSpeed > 2f && currentSpeed < 7f) {
			blankColors ();
			colors [2].color = new Color (7, 128, 57,255);
			Debug.Log ("Normal");
		}
		if (currentSpeed < 2f) {
			blankColors ();
			colors [2].color = new Color (178,25,53,255);
			Debug.Log ("Despacio");
		}
	}

	void blankColors()
	{
		foreach (Image color in colors) {
			color.color = new Color (73,73,73,255);
		}
	}
}
