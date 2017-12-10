using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acera : MonoBehaviour {

	public GameObject[] Edificios;
	public GameObject[] Arboles;

	int randomInt;
	int counter;
	int randomCounter;

	Transform thisTransform;

	void Init(){

		randomInt = 0;
		counter = 0;
		randomCounter = 0;
		thisTransform = gameObject.transform;
		counter = -1;
		for (int i = 0; i < 3; i++) {
			ponerEdificios(counter,1);
			counter++;
		}
		counter = -1;
		for (int i = 0; i < 3; i++) {
			ponerEdificios(counter,0);
			counter++;
		}
		counter = -1;
		for (int i = 0; i < 3; i++) {
			ponerEdificios(counter,-1);
			counter++;
		}
		randomCounter = Random.Range (-1, 6);
		for (int i = 0; i < randomCounter; i++) {
			ponerArboles("Frente");
		}
		randomCounter = Random.Range (-1, 6);
		for (int i = 0; i < randomCounter; i++) {
			ponerArboles("Arriba");
		}
		randomCounter = Random.Range (-1, 6);
		for (int i = 0; i < randomCounter; i++) {
			ponerArboles("Abajo");
		}
		randomCounter = Random.Range (-1, 6);
		for (int i = 0; i < randomCounter; i++) {
			ponerArboles("Atras");
		}
	}
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ponerEdificios(int x, int z)
	{
		randomInt = Random.Range (0, Edificios.Length);
		GameObject nuevoEdificio = Instantiate (Edificios[randomInt],thisTransform.position + new Vector3(x,0,z),thisTransform.rotation);
		nuevoEdificio.transform.parent = gameObject.transform;
	}


	void ponerArboles(string side)
	{
		float arbolX = Random.Range (-1.7f, 1.7f);
		float arbolZ = Random.Range (-1.7f, 1.7f);
		if(side.Equals("Frente")){
			arbolX = 1.78f;
		}		
		if(side.Equals("Atras")){
			arbolX = -1.78f;
		}
		if(side.Equals("Arriba")){
			arbolZ = -1.78f;
		}		
		if(side.Equals("Abajo")){
			arbolZ = 1.78f;
		}
		randomInt = Random.Range (0, Arboles.Length);
		GameObject nuevoArbol = Instantiate (Arboles[randomInt],thisTransform.position + new Vector3(arbolX,0,arbolZ),thisTransform.rotation);
		nuevoArbol.transform.parent = gameObject.transform;
	}
}
