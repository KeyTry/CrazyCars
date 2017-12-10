using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroEplode : MonoBehaviour {

	public GameObject originalMesh;

	public GameObject explodeMesh;
	private Animator animator;

	public float timeForEndCallback;

	public float timeScale;

	// Use this for initialization
	void Start () {
		animator = explodeMesh.GetComponent<Animator> ();

	}

	public void InvokeExplode(){
		Invoke ("Explode", 4f);
	}
	
	// Update is called once per frame
	public void Explode () {
		Invoke ("EndAnimation", timeForEndCallback);
		Time.timeScale = timeScale;

		originalMesh.SetActive (false);
		explodeMesh.SetActive (true);

		animator.SetTrigger ("Explode");
	}

	void EndAnimation(){
		Debug.Log ("Termino la animacion");
		Time.timeScale = 0f;
	}
}
