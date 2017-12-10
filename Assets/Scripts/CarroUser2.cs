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

	public AudioClip explosionSound;
	public AudioClip accelerationSound;
	AudioSource audioSource;

	public float tilt;

	private float velocity;

	private Rigidbody rigidbody;

	public bool toExplode;

	bool crash;

	void Awake ()
	{
		input = false;
		explode = gameObject.GetComponent<CarroEplode> ();
		rigidbody = GetComponent<Rigidbody> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (0.0f, 0.0f, constSpeed);
		if (input) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");


			if (moveVertical > 0) {
				moveVertical += (HightSpeed * moveVertical);
				if (!crash) {
					audioSource.clip = accelerationSound;
					audioSource.Play ();
				}
			} else {
				moveVertical += constSpeed;
				if (!crash) {
					audioSource.Stop ();
				}
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
				if (!crash) {
					audioSource.clip = explosionSound;
					audioSource.Play ();
					crash = true;
				}
				explode.Explode ();
			}
		}
	}
}
