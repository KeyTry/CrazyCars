using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class CarroUser2 : MonoBehaviour
{
	CarroEplode explode;
	CarroScript colScript;
	public float speed;
	public float constSpeed;
	public float HightSpeed;

	public float tilt;

	private float velocity;

	private Rigidbody rigidbody;

	void Awake ()
	{
		explode = gameObject.GetComponent<CarroEplode> ();
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		if (moveVertical > 0) {
			moveVertical += (HightSpeed * moveVertical);

		} else {
			moveVertical += constSpeed;
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.rotation = Quaternion.Euler (0.0f, rigidbody.velocity.x * -tilt, 0.0f);
	}
		 
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Car")) {
			Rigidbody colRb = col.gameObject.GetComponent<Rigidbody> ();
			if ((colRb.velocity.magnitude > 7f) && (colRb.velocity.magnitude > rigidbody.velocity.magnitude)) {
				explode.Explode ();			
			}
		}
	}
}
