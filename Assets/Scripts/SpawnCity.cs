using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCity : MonoBehaviour {

	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider col)
	{
		GameObject section = Instantiate ((Resources.Load("Section")) as GameObject, spawnPoint.position,spawnPoint.rotation);
	}
}
