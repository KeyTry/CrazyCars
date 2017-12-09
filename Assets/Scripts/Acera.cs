using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acera : MonoBehaviour {

	public GameObject[] Edificios;

	Transform thisTransform;

	Vector3 arriba;
	Vector3 centro;
	Vector3 abajo;

	// Use this for initialization
	void Start () {
		thisTransform = gameObject.transform;
		Instantiate (Edificios[1],gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
