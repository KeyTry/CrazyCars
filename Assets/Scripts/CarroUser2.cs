using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class CarroUser2 : MonoBehaviour
{
	public bool input;
	CarroEplode explode;
	CarroScript colScript;
	public float speed;
	public float constSpeed;
	public float HightSpeed;

	public float tilt;

	private float velocity;

	private Rigidbody rigidbody;

	public bool toExplode;

	void Awake ()
	{
		input = false;
		explode = gameObject.GetComponent<CarroEplode> ();
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (0.0f, 0.0f, constSpeed);
		if (input) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");


			if (moveVertical > 0) {
				moveVertical += (HightSpeed * moveVertical);

			} else {
				moveVertical += constSpeed;
			}

			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		}
		rigidbody.velocity = movement * speed;

		rigidbody.rotation = Quaternion.Euler (0.0f, rigidbody.velocity.x * -tilt, 0.0f);
	}
		 
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Car")) {
			if (toExplode) {
				explode.Explode ();
			}
		}
	}
}
