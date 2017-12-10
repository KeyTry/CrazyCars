using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

	CarroUser2 carro;
	void Start(){
		carro = FindObjectOfType<CarroUser2> ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Player")) {
			carro.ActivatePower (this);
		}
	}
}
