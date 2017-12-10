using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosDisplay : MonoBehaviour {

	public GameObject managerObject;
	public Rigidbody carro;
	GameManager gm;
	Text txt;
	Color32 redColor;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		gm = managerObject.GetComponent<GameManager> ();
		redColor = new Color32 (214,61,61,255);
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = ""+gm.displayPoints;
		Debug.Log ("magnitude: " + carro.velocity.magnitude);
		if (carro.velocity.magnitude > 18) {
			Debug.Log ("Changing color!");
			txt.color = redColor;
		}
		else
		{
			txt.color = Color.white;
		}
	}
}
