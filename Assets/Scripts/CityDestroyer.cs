using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDestroyer : MonoBehaviour {
	GameObject section;

	// Use this for initialization
	void Start () {
		section = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider col)
	{
		if (col.CompareTag ("Player")) {
			Destroy (section);
		}
	}
}
