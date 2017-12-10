using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroScript : MonoBehaviour {

	public float speed;	

	public Animator explodeAnimator;
	public GameObject originalMesh;
	public GameObject explodeMesh;

	private Rigidbody rb;

	void Awake(){
		originalMesh.SetActive (true);
		explodeMesh.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	public void InitVelocity () {
//		Vector3 movement = new Vector3 (0.0f, 0.0f, 
//			transform.forward * speed);

		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	public void Explode () {
		originalMesh.SetActive (false);
		explodeMesh.SetActive (true);

		explodeAnimator.SetTrigger ("Explode");
	}
}
