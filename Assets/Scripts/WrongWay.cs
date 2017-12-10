using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongWay : MonoBehaviour {

	public Text points;
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		points = GameObject.Find ("Text").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider other)
	{
		Debug.Log ("Something in collision");
		if (other.CompareTag ("Player")) {
			Debug.Log ("Wrong Way!");
			gameManager.points++;
			Debug.Log (gameManager.points);
			points.text = "Puntos: " + gameManager.points;
		}
	}
}
