using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGame : MonoBehaviour {

	public GameObject city;
	public GameObject carro;
	public GameObject uiStuff;
	public GameObject menuUI;
	public GameObject effTheRules;

	CarroUser2 carroScript;
	GameObject carSpawners;
	GameManager gm;

	static bool inicio = true;

	// Use this for initialization
	void Start () {
		carroScript = carro.GetComponent<CarroUser2>();
		carSpawners = city.transform.Find ("CarSpawners").gameObject;
		Debug.Log ("Found spawners!: "+carSpawners.name);
		gm = gameObject.GetComponent<GameManager> ();
		if (inicio) {
			DeactivateStuff ();
		} else {
			ActivateInit ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DeactivateStuff(){
		uiStuff.gameObject.SetActive (false);
		carroScript.input = false;
		carroScript.toExplode = false;
		carSpawners.SetActive(true);
		gm.countPoints = false;
		inicio = false;
	}

	public void ActivateInit()
	{
		uiStuff.gameObject.SetActive (false);
		carSpawners.SetActive(false);
		gm.countPoints = false;
		menuUI.gameObject.SetActive (false);
		carroScript.input = true;
		carroScript.toExplode = false;
		effTheRules.gameObject.SetActive (true);
	}

	public void ActivateStuff()
	{
		carroScript.toExplode = true;
		uiStuff.gameObject.SetActive (true);
		carSpawners.SetActive (true);
		gm.countPoints = true;
	}
}
